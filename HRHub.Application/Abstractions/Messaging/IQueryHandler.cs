using HRHub.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Abstractions.Messaging
{
    internal interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
       where TQuery : IQuery<TResponse>
    {

    }
}
