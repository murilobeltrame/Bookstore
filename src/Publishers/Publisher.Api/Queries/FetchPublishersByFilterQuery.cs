using Ardalis.Specification;
using Bookstore.CQRS.Interfaces;

namespace Publisher.Api.Queries
{
    public sealed record FetchPublishersByFilterQuery(string? name, int? skip, int? take)
        : IQuery<IEnumerable<Publisher>>
    {
        public ISpecification<Publisher> ToSpecification() =>
            new FetchPublishersByFilterSpecification(name, skip, take);
    }

    internal class FetchPublishersByFilterSpecification : Specification<Publisher>
    {
        public FetchPublishersByFilterSpecification(string? name, int? skip, int? take)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Query.Search(s => s.Name, name.Replace("*", "%"));

            Query
                .Skip(skip.GetValueOrDefault(0))
                .Take(take.GetValueOrDefault(10));
        }
    }
}
