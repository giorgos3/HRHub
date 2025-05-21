using HRHub.Domain.Request;

namespace HRHub.Api.Controllers.Requests
{
    public sealed record RequestLeave(
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate,
        TypeLeave Status
        );
  
    
}
