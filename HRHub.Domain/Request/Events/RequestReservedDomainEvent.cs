using HRHub.Domain.Abstractions;

namespace HRHub.Domain.Bookings.Events;

public sealed record RequestReservedDomainEvent(Guid RequestId) : IDomainEvent;