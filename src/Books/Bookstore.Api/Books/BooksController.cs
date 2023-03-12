using Bookstore.Api.Books.Commands;
using Bookstore.Api.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Books
{
	[ApiController]
	[Route("books")]
	public class BooksController: ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Fetch(
			[FromServices] IMediator mediator,
			[FromQuery] FetchBookQuery request)
		{
			return Ok(await mediator.Send(request));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(
			[FromServices] IMediator mediator,
			int id)
		{
			return Ok(await mediator.Send(new GetBookQuery(id)));
		}

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] IMediator mediator,
            [FromBody] CreateBookCommand request)
        {
            var response = await mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(
			[FromServices] IMediator mediator,
			[FromBody] UpdateBookCommand request,
			int id)
		{
			if (id != request.Id) return BadRequest(); // TODO: Não deveria ser necessário essa checagem na API
			await mediator.Send(request);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(
			[FromServices] IMediator mediator,
			int id)
		{
			await mediator.Send(new DeleteBookCommand(id));
			return NoContent();
		}
    }
}
