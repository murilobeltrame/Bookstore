using FluentValidation;

namespace Bookstore.Api.Books.Commands
{
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
	{
		public UpdateBookCommandValidator()
		{
			RuleFor(x => x.Publisher)
				.NotEmpty()
				.MaximumLength(50);

			RuleFor(x => x.Title)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(x => x.Id)
				.NotEmpty();
		}
	}
}
