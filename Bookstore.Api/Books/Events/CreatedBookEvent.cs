using System;
namespace Bookstore.Api.Books.Events
{
	public class CreatedBookEvent
	{
		public string Title { get; set; }
		public string Author { get; set; }

		public static CreatedBookEvent FromEntity(Book book) => new CreatedBookEvent
		{
			Title = book.Title,
			Author = book.AuthorName
		};
	}
}

