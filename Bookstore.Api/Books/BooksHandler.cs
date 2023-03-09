using Bookstore.Api.Books.Commands;
using Bookstore.Api.Books.Events;
using Bookstore.Api.Books.Queries;
using Bookstore.Api.Shared.Interfaces;
using MassTransit;
using MediatR;

namespace Bookstore.Api.Books
{
    public class BooksHandler:
        IQueryHandler<GetBookQuery, Book>,
        IQueryHandler<FetchBookQuery, IEnumerable<FetchBookQueryResponse>>,
        ICommandHandler<CreateBookCommand, CreateBookCommandResponse>,
        ICommandHandler<UpdateBookCommand>,
        ICommandHandler<DeleteBookCommand>
	{
        private readonly IPublishEndpoint _publisher;
        private readonly IRepository<Book> _repository;

        public BooksHandler(
            IPublishEndpoint publisher,
            IRepository<Book> repository)
        {
            _publisher = publisher;
            _repository = repository;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var createdBook = await _repository.Create(request.ToEntity(), cancellationToken);
            await _publisher.Publish(CreatedBookEvent.FromEntity(createdBook), cancellationToken);
            return CreateBookCommandResponse.FromEntity(createdBook);
        }

        public async Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id, cancellationToken);
        }

        public async Task<IEnumerable<FetchBookQueryResponse>> Handle(FetchBookQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Query(request.ToSpecification(), cancellationToken);
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Id, request.ToEntity(), cancellationToken);
            return new Unit();
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id, cancellationToken);
            return new Unit();
        }
    }
}
