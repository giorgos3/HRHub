using HRHub.Application.Abstractions.Messaging;
using HRHub.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRHub.Domain.Users;
using HRHub.Domain.Request;
using MediatR;
using HRHub.Application.Abstractions.Clock;
using HRHub.Application.Exceptions;

namespace HRHub.Application.Request
{
    internal sealed class RequestLeaveCommandHandler: ICommandHandler<RequestLeaveCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public RequestLeaveCommandHandler(
            IUserRepository userRepository,
            IRequestRepository  requestRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider
            )
        {
            _userRepository = userRepository;
            _requestRepository = requestRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<Result<Guid>> Handle(RequestLeaveCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
            if (user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }
            var duration = DateRange.Create(command.StartDate, command.EndDate, user.RemaingLeave);

            if (await _requestRepository.IsOverlappingAsync(duration, cancellationToken))
            {
                return Result.Failure<Guid>(RequestErrors.Overlap);
            }

            try
            {
                var request = HRHub.Domain.Request.Request.RequestLeave(
                    Guid.NewGuid(),
                    command.UserId,
                    duration,
                    command.Status,
                    _dateTimeProvider.UtcNow,
                    user.RemaingLeave
                    );

                _requestRepository.Add(request);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return request.Id;
            }
            catch (ConcurrencyException) 
            {
                return Result.Failure<Guid>(RequestErrors.Overlap);
            }


        }
    }
}
