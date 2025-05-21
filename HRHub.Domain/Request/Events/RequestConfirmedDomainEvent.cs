using HRHub.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Domain.Request.Events
{
    public sealed record RequestConfirmedDomainEvent(Guid requestId) : IDomainEvent;
}
