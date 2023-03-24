namespace Bookstore.GraphQl.Types
{
    public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public IEnumerable<Author> Authors { get; set; }
		public Publisher Publisher { get; set; }
	}
}
