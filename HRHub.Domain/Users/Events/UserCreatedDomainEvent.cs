﻿

using HRHub.Domain.Abstractions;

namespace HRHub.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid userId): IDomainEvent;
   
}
