using HRHub.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Request.GetRequest
{
    public sealed record GetRequestQuery(Guid RequestId) : IQuery<RequestResponse>
    {
    }
}
