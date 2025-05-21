using HRHub.Application.Abstractions.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Infrastructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendManagerRequestAsync(string ManagerEmail, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
