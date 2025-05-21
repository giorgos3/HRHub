using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Abstractions.Behaviors
{
    public sealed record validationError(string PropertyName, string ErrorMessage);
  
}
