using Bookstore.Api.Models;
using Bookstore.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Bookstore.Api.Shared.Midlewares
{
    public class ExceptionHandlingMiddleware: IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var title = GetTitle(exception);
            var errors = GetErrors(exception);

            context.Response.StatusCode = statusCode;
            if (errors.Count() == 1)
            {
                var error = errors.First();
                await context.Response.WriteAsJsonAsync(new
                {
                    title,
                    type = error.GetType().Name,
                    message = error.Description,
                });
            }else
            {
                await context.Response.WriteAsJsonAsync(new
                {
                    title,
                    errors = errors.Select(e => e)
                });
            }
        }

        private IEnumerable<Error> GetErrors(Exception exception)
        {
            var errors = new List<Error>();
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors
                    .Select(s => new Error(s.GetType().Name, s.ErrorMessage))
                    .ToList();
            }
            else if (exception is AggregateException aggregateException)
            {
                errors = aggregateException.InnerExceptions
                    .Select(s => new Error(s))
                    .ToList();
            }
            else
            {
                errors.Add(new Error(exception));
            }
            return errors;
        }

        private string GetTitle(Exception exception) =>
            exception switch
            {
                ApplicationException applicationException => applicationException.Message,
                _ => "Server Error"
            };

        private int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                // UNAUTHORIZED
                // FORBIDEN
                NotFoundException => StatusCodes.Status404NotFound, // -- when payload has missing or invalid content
                // CONFLICT -- when failing to write data because of a conflict
                // PRECONDITION FAILED -- when data rules deny write new data
                // PAYLOAD TOO LARGE -- when data is larger than allowed
                // UNSUPPORTED MEDIA TYPE -- when data has format other than expected
                ValidationException => StatusCodes.Status422UnprocessableEntity, // -- ??
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
