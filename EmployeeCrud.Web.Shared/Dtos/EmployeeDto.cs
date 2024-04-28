namespace EmployeeCrud.Web.Shared.Dtos;
public class EmployeeDto
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public required string Description { get; set; }
}
