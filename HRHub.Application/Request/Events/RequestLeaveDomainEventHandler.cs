using HRHub.Application.Abstractions.Email;
using HRHub.Domain.Bookings.Events;
using HRHub.Domain.Request;
using HRHub.Domain.Request.Events;
using HRHub.Domain.Users;
using MediatR;

namespace HRHub.Application.Request.Events
{
    internal sealed class RequestLeaveDomainEventHandler : INotificationHandler<RequestReservedDomainEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;

        public RequestLeaveDomainEventHandler(IEmailService  emailService , IRequestRepository requestRepository, IUserRepository userRepository)
        {
            _emailService = emailService;
            _requestRepository = requestRepository;
            _userRepository = userRepository;
        }



        public async Task Handle(RequestReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetByIdAsync(notification.RequestId, cancellationToken);
            if (request is null)
            {
                return;
            }
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
            {
                return;
            }
            if (user.ManagerId is null)
                return;

            var manager = await _userRepository.GetByIdAsync(user.ManagerId.Value, cancellationToken);
            if (manager is null)
                return;

            var subject = "Leave Request Notification";
            var body = $"{user.FirstName.Value} {user.LastName.Value} has requested {request.TypeLeave} from {request.Duration.Start} to {request.Duration.End}.";

            await _emailService.SendManagerRequestAsync(manager.Email.Value, subject, body);


        }
    }
}
