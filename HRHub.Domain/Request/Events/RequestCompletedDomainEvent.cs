using HRHub.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record RequestCompletedDomainEvent(Guid requestId) : IDomainEvent;