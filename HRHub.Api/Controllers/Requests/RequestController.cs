using HRHub.Application.Request;
using HRHub.Application.Request.GetRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRHub.Api.Controllers.Requests
{
    [Route("api/requests")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ISender _sender;
    
        public RequestController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetRequestFromUser(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetRequestQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : NotFound();


        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(RequestLeave request, CancellationToken cancellationToken)
        {
            var command = new RequestLeaveCommand(
                 request.UserId,
                request.StartDate,
                request.EndDate,
                request.Status);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetRequestFromUser), new { id = result.Value }, result.Value);



        }
    }
}
