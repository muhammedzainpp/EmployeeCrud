using EmployeeCrud.Web.Client.Services.Employees;
using EmployeeCrud.Web.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace EmployeeCrud.Web.Client.Views;

public partial class EmployeeListView
{
    [Inject]
    public IEmployeeService Service { get; set; } = default!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;
    public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

    event Action ProductDeleted =default!;

    protected override async Task OnInitializedAsync()
    {
        Employees = await Service.GetAllEmployees();
    }
    public void  NavigateToEdit(int id , string name ,string description)
    {
        NavigationManager.NavigateTo($"create/{id}/{name}/{description}");
    }
    public async Task DeleteEmployee(int id)
    {
        await Service.DeleteEmployee(id);

        ProductDeleted.Invoke();
    }

}
