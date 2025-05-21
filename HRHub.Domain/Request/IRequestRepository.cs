using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Domain.Request
{
    public interface IRequestRepository
    {
        Task<Request?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(
            DateRange duration,
            CancellationToken cancellationToken = default);

        void Add(Request request);
    }
}
