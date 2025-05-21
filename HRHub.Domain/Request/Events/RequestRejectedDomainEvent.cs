using HRHub.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record RequestRejectedDomainEvent(Guid requestId) : IDomainEvent;