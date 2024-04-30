using EmployeeCrud.Web.Client.Dtos;
using EmployeeCrud.Web.Client.Services.Common;
using EmployeeCrud.Web.Shared.Dtos;

namespace EmployeeCrud.Web.Client.Services.Employees;

public class EmployeeService(IApiServices apiServices) : IEmployeeService
{
    private string _baseUrl = "api/employees";
    private readonly IApiServices _apiServices = apiServices;

    public async  Task<IEnumerable<EmployeeDto>> GetAllEmployees()
    {
        var response = await _apiServices.Get<IEnumerable<EmployeeDto>>(_baseUrl) ;
        var employeelist = response.Result is not  null ? response.Result : default!;
        return employeelist ;
    }

    public async Task<int> SaveEmployee(SaveEmployeeDto request)
    {
        var response = await _apiServices.Post<SaveEmployeeDto>(_baseUrl,request);
        return response.Result;
    }
    public async Task  DeleteEmployee(int id)
    {
        var response = await _apiServices.Delete(_baseUrl, id);
        
    }
}
