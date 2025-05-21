using HRHub.Application.Abstractions.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<validationError> errors) 
        {
            Errors = errors;
        }

        public IEnumerable<validationError> Errors { get; }
    }
}
