using System.Net;
using Bookstore.Api.Authors.Commands;
using Bookstore.Api.Authors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Authors
{
	[ApiController]
	[Route("authors")]
	public class AuthorsController : ControllerBase
	{
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Author>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Fetch(
            [FromServices] IMediator mediator,
            [FromQuery] FetchAuthorsQuery request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Author), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            int id)
        {
            return Ok(await mediator.Send(new GetAuthorQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Author), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(
            [FromServices] IMediator mediator,
            [FromBody] CreateAuthorCommand request)
        {
            var response = await mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(
            [FromServices] IMediator mediator,
            [FromBody] UpdateAuthorCommand request,
            int id)
        {
            if (id != request.Id) return BadRequest(); // TODO: Não deveria ser necessário essa checagem na API
            await mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(
            [FromServices] IMediator mediator,
            int id)
        {
            await mediator.Send(new DeleteAuthorCommand(id));
            return NoContent();
        }
    }
}
