using HRHub.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Request.GetRequest
{
    public sealed class RequestResponse
    {
        public Guid Guid { get; init; }

        public Guid UserId { get; init; }

        public DateRange Duration { get; init; }

        public TypeLeave TypeLeave { get; init; }

        public RequestStatus Status { get; init; }

        public DateTime CreatedOnUtc { get; private set; }

        public DateTime? ConfirmedOnUtc { get; private set; }

        public DateTime? RejectedOnUtc { get; private set; }

        public DateTime? CompletedOnUtc { get; private set; }

        public DateTime? CancelledOnUtc { get; private set; }
    }
}
