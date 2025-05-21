using HRHub.Domain.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Infrastructure.Repositories
{
    internal sealed class RequestRepository : Repository<Request> , IRequestRepository
    {

        private static readonly RequestStatus[] Status =
        {
            RequestStatus.Confirmed,
            RequestStatus.Cancelled,
            RequestStatus.Rejected,


        };


        public RequestRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<bool> IsOverlappingAsync(
            DateRange duration,
            CancellationToken cancellationToken = default
            )
        {
            return await DbContext
                .Set<Request>().AnyAsync(
                    request =>
                    request.Duration.Start <= duration.End &&
                    request.Duration.End >= duration.Start &&
                    Status.Contains(request.Status),
                    cancellationToken);
        }
    }
}
