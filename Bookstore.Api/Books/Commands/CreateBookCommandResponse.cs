namespace Bookstore.Api.Books.Commands
{
    public class CreateBookCommandResponse
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;

        public static CreateBookCommandResponse FromEntity(Book entity)
			=> new()
            {
				Id = entity.Id,
				Title = entity.Title,
				Author = entity.AuthorName
			};
    }
}
