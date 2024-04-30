using EmployeeCrud.Web.Client.Dtos;
using EmployeeCrud.Web.Shared.Dtos;

namespace EmployeeCrud.Web.Client.Services.Employees;

public interface IEmployeeService
{
    Task DeleteEmployee(int id);
    Task<IEnumerable<EmployeeDto>> GetAllEmployees();
    Task<int> SaveEmployee(SaveEmployeeDto request);
}
