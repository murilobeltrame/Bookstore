using Bookstore.GraphQl.Services;

namespace Bookstore.GraphQl
{
    public class Query
	{
		public Task<ICollection<FetchBookQueryResponse>> GetBooks(
			[Service] BooksClient client,
			CancellationToken cancellationToken,
            string? title,
            string? author,
            int? skip = 0,
            int? take = 10)
		{
			return client.BooksAllAsync(skip, take, title, author, cancellationToken);
		}

		public Task<GetBookQueryResponse> GetBook(
			[Service] BooksClient client,
			int id,
			CancellationToken cancellationToken)
		{
			return client.BooksGETAsync(id, cancellationToken);
		}

		public Task<ICollection<Author>> GetAuthors(
			[Service] BooksClient client,
			CancellationToken cancellationToken,
			string? name,
			int? skip = 0,
			int? take = 10)
		{
			return client.AuthorsAllAsync(skip, take, name, cancellationToken);
		}

		public Task<Author> GetAuthor(
			[Service] BooksClient client,
			CancellationToken cancellationToken,
			int id)
		{
			return client.AuthorsGETAsync(id, cancellationToken);
		}

		public Task<ICollection<Publisher>> GetPublishers(
			[Service] PublishersClient client,
			CancellationToken cancellationToken,
            string? name,
            int? skip = 0,
            int? take = 10)
		{
			return client.PublishersAllAsync(name, skip, take, cancellationToken);
		}

		public Task<Publisher> GetPublisher(
			[Service] PublishersClient client,
            int id,
            CancellationToken cancellationToken)
		{
			return client.PublishersGETAsync(id, cancellationToken);
		}
	}
}
