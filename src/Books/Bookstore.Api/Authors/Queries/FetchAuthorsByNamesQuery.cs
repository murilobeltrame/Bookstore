using Ardalis.Specification;
using Bookstore.CQRS.Interfaces;

namespace Bookstore.Api.Authors.Queries
{
    public sealed record FetchAuthorsByNamesQuery(IEnumerable<string> Names) : IQuery<IEnumerable<Author>>
    {
        internal ISpecification<Author> ToSpecification() =>
            new AuthorsByNamesSpecification(Names);
    }

    public class AuthorsByNamesSpecification : Specification<Author>
    {
        public AuthorsByNamesSpecification(IEnumerable<string> names)
        {
            Query.Where(w => names.Contains(w.Name));
        }
    }
}
