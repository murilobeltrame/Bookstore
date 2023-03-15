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
        IQueryHandler<GetAuthorQuery, Author>
    {
        private readonly IRepository<Author> _repository;

        public AuthorsHandler(IRepository<Author> repository) =>
            _repository = repository;

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Create(request.ToEntity(), cancellationToken);
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Id, request.ToEntity(), cancellationToken);
            return new();
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id, cancellationToken);
            return new();
        }

        public async Task<IEnumerable<Author>> Handle(FetchAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Query(request.ToSpecification(), cancellationToken);
        }

        public async Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id, cancellationToken);
        }
    }
}
