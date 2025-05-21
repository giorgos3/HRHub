using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Request.GetRequest
{
    internal class RequestLeaveValidator : AbstractValidator<RequestLeaveCommand>
    {
        public RequestLeaveValidator()
        {

            RuleFor(c => c.UserId).NotEmpty();

            RuleFor(c => c.StartDate).LessThan(c => c.EndDate);

            RuleFor(c => c.Status).NotEmpty();


        }
    }
}
