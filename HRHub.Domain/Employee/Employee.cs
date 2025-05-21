namespace HRHub.Domain.Abstractions;

public sealed class Employee : Entity
{

    public Employee(Guid id) : base(id)
    {
        
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Department { get; private set; }
    
}