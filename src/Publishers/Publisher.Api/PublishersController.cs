using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publisher.Api.Commands;
using Publisher.Api.Queries;

namespace Publisher.Api
{
	[ApiController]
	[Route("publishers")]
	public class PublishersController : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Publisher>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Fetch(
			[FromServices] IMediator mediator,
			[FromQuery] FetchPublishersByFilterQuery request)
		{
			return Ok(await mediator.Send(request));
		}

		[HttpGet("{id}")]
        [ProducesResponseType(typeof(Publisher), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(
			[FromServices] IMediator mediator,
			int id)
		{
			return Ok(await mediator.Send(new GetPublisherByIdQuery(id)));
		}

		[HttpPost]
        [ProducesResponseType(typeof(Publisher), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(
			[FromServices] IMediator mediator,
			[FromBody] CreatePublisherCommand request)
		{
			var response = await mediator.Send(request);
			return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
		}

		[HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(
			[FromServices] IMediator mediator,
			[FromBody] UpdatePublisherCommand request,
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
            await mediator.Send(new DeletePublisherCommand(id));
            return NoContent();
        }
    }
}
