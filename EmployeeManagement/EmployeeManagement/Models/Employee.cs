namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
    }
}
