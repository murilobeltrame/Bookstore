using Bookstore.GraphQl.Types;

namespace Bookstore.GraphQl
{
    public class Query
	{
		public Book GetBook() => new()
		{
			Author = new() { Name = "Jon Skeet" },
			Title = "C# in depth"
		};
	}
}

