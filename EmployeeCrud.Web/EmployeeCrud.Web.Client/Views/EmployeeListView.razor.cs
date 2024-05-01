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
    public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();


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
        StateHasChanged();
        var employee = Employees.Find(x=>x.Id == id)??default!;
        Employees.Remove(employee);   
    }

}
