using Bookify.Domain.Bookings.Events;
using HRHub.Domain.Abstractions;
using HRHub.Domain.Request.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Domain.Request
{
    public sealed class Request : Entity
    {
        private Request(Guid id, Guid userId, DateRange duration, TypeLeave typeleave) : base(id)
        {
            UserId = userId;
            Duration = duration;
            TypeLeave = typeleave;

        }

        public Guid UserId { get; private set; }

        public Guid? ManagerId { get; private set; }

        public DateRange Duration { get; private set; }

        public TypeLeave TypeLeave { get; private set; }

        public RequestStatus Status { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }

        public DateTime? ConfirmedOnUtc { get; private set; }

        public DateTime? RejectedOnUtc { get; private set; }

        public DateTime? CompletedOnUtc { get; private set; }

        public DateTime? CancelledOnUtc { get; private set; }


        public static Request RequestLeave(
            Guid id,
            Guid userId,
            DateRange duration,
            TypeLeave status,
            DateTime utcNow,
            int remainingLeaveDays)
        {

 
            var reqeust = new Request(Guid.NewGuid(), userId, duration, status);

            reqeust.RaiseDomainEvent(new RequestLeaveDomainEvent(reqeust.Id));


            return reqeust;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status != RequestStatus.Rejected || Status != RequestStatus.Cancelled)
            {
                return Result.Failure(RequestErrors.NotConfirmed);
            }

            Status = RequestStatus.Confirmed;
            ConfirmedOnUtc = utcNow;

            RaiseDomainEvent(new RequestConfirmedDomainEvent(Id));


            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != RequestStatus.Confirmed)
            {
                return Result.Failure(RequestErrors.NotConfirmed);
            }

            Status = RequestStatus.Rejected;
            RejectedOnUtc = utcNow;

            RaiseDomainEvent(new RequestRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status != RequestStatus.Confirmed)
            {
                return Result.Failure(RequestErrors.NotConfirmed);
            }

            Status = RequestStatus.Confirmed;
            CompletedOnUtc = utcNow;

            RaiseDomainEvent(new RequestCompletedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != RequestStatus.Confirmed)
            {
                return Result.Failure(RequestErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.Start)
            {
                return Result.Failure(RequestErrors.AlreadyStarted);
            }

            Status = RequestStatus.Cancelled;
            CancelledOnUtc = utcNow;

            RaiseDomainEvent(new RequestCancelledDomainEvent(Id));

            return Result.Success();
        }

        


    }
}
