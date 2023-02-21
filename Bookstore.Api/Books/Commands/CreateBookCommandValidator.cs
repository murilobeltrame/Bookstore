using FluentValidation;

namespace Bookstore.Api.Books.Commands
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
