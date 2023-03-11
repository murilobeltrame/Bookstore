using Ardalis.Specification;
using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Authors.Queries
{
    public sealed record FetchAuthorsQuery(int? skip, int? take, string? name)
        : IQuery<IEnumerable<Author>>
    {
        public ISpecification<Author> ToSpecification() =>
            new FetchFilteredAuthorsPaginatedSpecification(skip, take, name);
    }

    public sealed class FetchFilteredAuthorsPaginatedSpecification : Specification<Author>
    {
        public FetchFilteredAuthorsPaginatedSpecification(int? skip, int? take, string? name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Query.Search(a => a.Name, name.Replace("*", "%"));

            Query
                .Skip(skip.GetValueOrDefault(0))
                .Take(take.GetValueOrDefault(10));
        }
    }
}
