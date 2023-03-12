using Ardalis.Specification;
using Bookstore.Api.Shared.Interfaces;

namespace Bookstore.Api.Books.Queries
{
    public sealed record GetBookQuery(int Id) : IQuery<GetBookQueryResponse>
    {
        public ISpecification<Book, GetBookQueryResponse> ToSpecification() =>
            new GetBookByIdSpecification(Id);
    }

    public sealed class GetBookByIdSpecification : Specification<Book, GetBookQueryResponse>
    {
        public GetBookByIdSpecification(int Id)
        {
            Query.Include(i => i.Authors);
            Query.Where(w => w.Id == Id);
            Query.Select(s => GetBookQueryResponse.FromEntity(s));
        }
    }
}
