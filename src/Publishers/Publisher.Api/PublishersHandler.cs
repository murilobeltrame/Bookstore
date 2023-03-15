using Bookstore.CQRS.Interfaces;
using MediatR;
using Publisher.Api.Commands;
using Publisher.Api.Queries;

namespace Publisher.Api
{
	public class PublishersHandler:
		ICommandHandler<CreatePublisherCommand, Publisher>,
		ICommandHandler<UpdatePublisherCommand>,
		ICommandHandler<DeletePublisherCommand>,
        IQueryHandler<GetPublisherByIdQuery, Publisher>,
        IQueryHandler<FetchPublishersByFilterQuery, IEnumerable<Publisher>>
	{
		private readonly IRepository<Publisher> _repository;

		public PublishersHandler(IRepository<Publisher> repository) => _repository = repository;

        public Task<Publisher> Handle(CreatePublisherCommand request, CancellationToken cancellationToken) =>
            _repository.Create(request.ToEntity(), cancellationToken);

        public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Id, request.ToEntity(), cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }

        public Task<Publisher> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken) =>
            _repository.Get(request.Id, cancellationToken);

        public Task<IEnumerable<Publisher>> Handle(FetchPublishersByFilterQuery request, CancellationToken cancellationToken) =>
            _repository.Query(request.ToSpecification(), cancellationToken);
    }
}