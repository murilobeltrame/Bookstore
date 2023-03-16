using Bookstore.Api.Authors.Commands;
using Bookstore.Api.Authors.Queries;
using Bookstore.CQRS.Interfaces;
using MediatR;

namespace Bookstore.Api.Authors
{
	public class AuthorsHandler:
		ICommandHandler<CreateAuthorCommand, Author>,
        ICommandHandler<UpdateAuthorCommand>,
        ICommandHandler<DeleteAuthorCommand>,
        IQueryHandler<FetchAuthorsQuery, IEnumerable<Author>>,
        IQueryHandler<FetchAuthorsByNamesQuery, IEnumerable<Author>>,
        IQueryHandler<GetAuthorQuery, Author>
    {
        private readonly IRepository<Author> _repository;

        public AuthorsHandler(IRepository<Author> repository) =>
            _repository = repository;

        public Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken) =>
            _repository.Create(request.ToEntity(), cancellationToken);

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Id, request.ToEntity(), cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }

        public Task<IEnumerable<Author>> Handle(FetchAuthorsQuery request, CancellationToken cancellationToken) =>
            _repository.Query(request.ToSpecification(), cancellationToken);

        public Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken) =>
            _repository.Get(request.Id, cancellationToken);

        public Task<IEnumerable<Author>> Handle(FetchAuthorsByNamesQuery request, CancellationToken cancellationToken) =>
            _repository.Query(request.ToSpecification(), cancellationToken);
    }
}
