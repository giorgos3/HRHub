namespace HRHub.Domain.Abstractions;

public enum LeaveStatus
{
    Pending,
    Approved,
    Rejected
}

public class LeaveRequest : Entity
{

    public LeaveRequest(Guid id) : base(id)
    {

    }

    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Reason { get; private set; } = string.Empty;
    public LeaveStatus Status { get; private set; } = LeaveStatus.Pending;
    public DateTime RequestedAt { get; private set; } = DateTime.UtcNow;
}
