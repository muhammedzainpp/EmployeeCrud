namespace EmployeeCrud.Web.Apis;

public static class EndPoints
{
    public static void MapEndPoints(this RouteGroupBuilder app)
    {
        app.MapEmployees();
    }
}
