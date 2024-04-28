namespace EmployeeCrud.Web.Domain.Entities;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

}
