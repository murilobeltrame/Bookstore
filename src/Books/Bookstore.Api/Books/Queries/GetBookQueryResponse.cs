namespace Bookstore.Api.Books.Queries
{
	public class GetBookQueryResponse
	{
        public IEnumerable<string>? AuthorNames { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;

        public static GetBookQueryResponse FromEntity(Book book) => new GetBookQueryResponse
        {
            AuthorNames = book.Authors.Select(s => s.Name),
            Publisher = book.Publisher,
            Title = book.Title
        };
    }
}
