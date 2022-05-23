using System.Net;
using Microsoft.AspNetCore.Mvc;
using ORG.TicketService.Application;

namespace ORG.TicketService.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse(ResponseHandler response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequestResponse(response),
                HttpStatusCode.OK => OkResponse(response),
                HttpStatusCode.NotFound => NotFoundResponse(response),
                HttpStatusCode.UnprocessableEntity => UnprocessableEntityResponse(response),
                _ => NoContent()
            };
        }

        private IActionResult BadRequestResponse(ResponseHandler response)
        {
            return response.Messages.Any()
                ? BadRequest(new { response.Messages })
                : BadRequest();
        }

        private IActionResult OkResponse(ResponseHandler response)
        {
            return response.Data != null
                ? Ok(response.Data)
                : Ok();
        }
        
        private IActionResult NotFoundResponse(ResponseHandler response)
        {
            return response.Messages.Any()
                ? NotFound(new { response.Messages })
                : NotFound();
        }

        private IActionResult UnprocessableEntityResponse(ResponseHandler response)
        {
            return response.Messages.Any()
                ? UnprocessableEntity(response.Messages)
                : UnprocessableEntity();
        }
    }
}