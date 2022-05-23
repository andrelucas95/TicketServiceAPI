using MediatR;

namespace ORG.TicketService.Application.Queries.GetTicketById;

public class GetTicketByIdQuery : IRequest<ResponseHandler>
{
    public GetTicketByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}