using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendManagerRequestAsync(string ManagerEmail, string subject, string body);
    }
}
