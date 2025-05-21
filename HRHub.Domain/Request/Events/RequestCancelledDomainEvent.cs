using HRHub.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public sealed record RequestCancelledDomainEvent(Guid requestId) : IDomainEvent;