using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HRHub.Application.Abstractions.Messaging;
using HRHub.Domain.Request;

namespace HRHub.Application.Request
{
    public record RequestLeaveCommand(
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate,
        TypeLeave Status
        ) : ICommand<Guid>;
   
}
