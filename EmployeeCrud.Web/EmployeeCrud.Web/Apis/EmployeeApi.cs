namespace EmployeeCrud.Web.Apis;

public static class EmployeeApi
{
    public static void MapEmployees(this RouteGroupBuilder app)
    {
        var group = app.MapGroup("employees");
    }
}
