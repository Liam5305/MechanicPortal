namespace MechanicPortal.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DoB { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
