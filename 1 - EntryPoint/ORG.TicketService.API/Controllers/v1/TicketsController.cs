using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ORG.TicketService.Application.Commands.CancelTicket;
using ORG.TicketService.Application.Commands.FinishTicket;
using ORG.TicketService.Application.Commands.ListTickets;
using ORG.TicketService.Application.Commands.OpenTicket;
using ORG.TicketService.Application.Queries.GetTicketById;
using ORG.TicketService.Application.Queries.ListTickets;
using ORG.TicketService.Domain.Repositories;

namespace ORG.TicketService.API.Controllers.v1
{
    [ApiController]
    [Route("v1/tickets")]
    public class TicketsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ITicketRepository _ticketRepository;
        
        public TicketsController(IMediator mediator, ITicketRepository ticketRepository)
        {
            _mediator = mediator;
            _ticketRepository = ticketRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListTickets([FromQuery] ListTicketQuery query)
        {
            var response = await _mediator.Send(query);
            return CreateResponse(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicketById([FromRoute] int id)
        {
            var query = new GetTicketByIdQuery(id);
            var result = await _mediator.Send(query);
            return CreateResponse(result);
        }
        
        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> OpenTicket(OpenTicketRequest request)
        {
            var response = await _mediator.Send(request);
            return CreateResponse(response);
        }
        
        [HttpPatch("{id:int}/finish")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> FinishTicket([FromRoute] int id)
        {
            var response = await _mediator.Send(new FinishTicketRequest(id));
            return CreateResponse(response);
        }
        
        [HttpPatch("{id:int}/cancel")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CancelTicket([FromRoute] int id)
        {
            var response = await _mediator.Send(new CancelTicketRequest(id));
            return CreateResponse(response);
        }
    }
}