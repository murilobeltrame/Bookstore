using Bookstore.GraphQl.Services;

namespace Bookstore.GraphQl
{
    public class Query
	{
		public Task<ICollection<FetchBookQueryResponse>> GetBooks(
			[Service] BooksClient client,
			CancellationToken cancellationToken)
		{
			Console.WriteLine($"Calling service based on {client.BaseUrl}");
			return client.BooksAllAsync(0, 100, string.Empty, string.Empty, cancellationToken);
		}

		public Task<GetBookQueryResponse> GetBook(
			[Service] BooksClient client,
			int id,
			CancellationToken cancellationToken)
		{
			return client.BooksGETAsync(id, cancellationToken);
		}
	}
}
