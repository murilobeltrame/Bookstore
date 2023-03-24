using Bookstore.Api.Authors.Queries;
using Bookstore.Api.Books.Commands;
using Bookstore.Api.Books.Events;
using Bookstore.Api.Books.Queries;
using Bookstore.CQRS.Interfaces;
using MassTransit;
using MediatR;

namespace Bookstore.Api.Books
{
    public class BooksHandler:
        IQueryHandler<GetBookQuery, GetBookQueryResponse>,
        IQueryHandler<FetchBookQuery, IEnumerable<FetchBookQueryResponse>>,
        ICommandHandler<CreateBookCommand, CreateBookCommandResponse>,
        ICommandHandler<UpdateBookCommand>,
        ICommandHandler<DeleteBookCommand>
	{
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publisher;
        private readonly IRepository<Book> _repository;

        public BooksHandler(
            IMediator mediator,
            IPublishEndpoint publisher,
            IRepository<Book> repository)
        {
            _mediator = mediator;
            _publisher = publisher;
            _repository = repository;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var existingAuthors = await _mediator.Send(
                new FetchAuthorsByNamesQuery(request.Authors.Select(s => s.Name)),
                cancellationToken);
            var createdBook = await _repository.Create(request.ToEntity(existingAuthors), cancellationToken);
            await _publisher.Publish(CreatedBookEvent.FromEntity(createdBook), cancellationToken);
            return CreateBookCommandResponse.FromEntity(createdBook);
        }

        public async Task<GetBookQueryResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.ToSpecification(), cancellationToken);
        }

        public async Task<IEnumerable<FetchBookQueryResponse>> Handle(FetchBookQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Query(request.ToSpecification(), cancellationToken);
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Id, request.ToEntity(), cancellationToken);
            return new();
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id, cancellationToken);
            return new();
        }
    }
}
