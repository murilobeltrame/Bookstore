using System;
namespace Bookstore.Api.Books.Queries
{
	public class FetchBookQueryResponse
	{
		public string Author { get; set; }
		public string Title { get; set; }

		public static FetchBookQueryResponse FromEntity(Book book) => new FetchBookQueryResponse { Author = book.AuthorName, Title = book.Title };
    }
}

