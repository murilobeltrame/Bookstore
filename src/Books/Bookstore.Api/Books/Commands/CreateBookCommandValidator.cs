using FluentValidation;

namespace Bookstore.Api.Books.Commands
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Publisher)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
