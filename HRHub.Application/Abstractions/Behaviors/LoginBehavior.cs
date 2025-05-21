using HRHub.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Abstractions.Behaviors
{
    public class LoginBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoginBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;


            try {

                _logger.LogInformation("Executing command {Command}", name);
               
                var result = await next();

                _logger.LogInformation("Command {Command} processed succesfully", name);

                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Executing command {Command}", name);

                throw;
            }
        }
    }
}
