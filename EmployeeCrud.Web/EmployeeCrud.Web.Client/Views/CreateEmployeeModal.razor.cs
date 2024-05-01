using EmployeeCrud.Web.Client.Dtos;
using EmployeeCrud.Web.Client.Services.Employees;
using Microsoft.AspNetCore.Components;

namespace EmployeeCrud.Web.Client.Views;

public partial class CreateEmployeeModal
{
    [Inject]
    public IEmployeeService Service { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    [SupplyParameterFromForm]
    public SaveEmployeeDto Employee { get; set; } = new SaveEmployeeDto();

    [Parameter]
    public int EmployeeId { get; set; }
    [Parameter]
    public string Name { get; set; } = default!;
    [Parameter]
    public string Description { get; set; } = default!;

    protected override Task OnParametersSetAsync()
    {
        Employee.Id = EmployeeId;
        Employee.Name = Name;
        Employee.Description = Description;
        return base.OnParametersSetAsync();
    }
    public async Task CreateEmployee()
    {
        await Service.SaveEmployee(Employee);
        NavigationManager.NavigateTo("employeelist");
    }
   
}
