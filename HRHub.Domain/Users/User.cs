using HRHub.Domain.Users;
using HRHub.Domain.Users.Events;
using HRHub.Domain.Abstractions;
using System.Data;

namespace HRHub.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, FirstName firstName, LasttName lastName, Email email, UserRole role, Guid? managerId = null) :
    base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        Email = email;
        ManagerId = role == UserRole.Employee ? managerId : null;
    }

    public FirstName FirstName { get; private set; }
    public LasttName LastName { get; private set; }
    public Email Email { get; private set; }
    public int RemaingLeave { get; private set; }
    public UserRole Role { get; private set; }

    public Guid? ManagerId { get; private set; }

    public void AssignManager(Guid managerId)
    {
        if (Role != UserRole.Employee)
        {
            throw new Exception("Only employees can be assigned a manager.");
        }

        ManagerId = managerId;
    }

    // Navigation
    public ICollection<LeaveRequest> LeaveRequests { get; private set; } = new List<LeaveRequest>();

    public static User Create(FirstName firstName, LasttName lastName, Email email, UserRole role, Guid? managerId = null)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email, role, managerId);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
