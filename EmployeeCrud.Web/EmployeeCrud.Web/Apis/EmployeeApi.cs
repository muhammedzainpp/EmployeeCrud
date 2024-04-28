
using EmployeeCrud.Web.Application.Employees.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Web.Apis;

public static class EmployeeApi
{
    public static void MapEmployees(this RouteGroupBuilder app)
    {
        var group = app.MapGroup("employees");
        group.MapPost("/",SaveEmployee);
    }

    private static async Task<IResult> SaveEmployee([FromServices] IMediator mediator , [FromBody] SaveEmployeeCommand request)
    {
        var response = await mediator.Send(request);
        return Results.Ok(response);
    }
}
