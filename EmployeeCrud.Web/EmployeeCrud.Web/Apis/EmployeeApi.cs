
using EmployeeCrud.Web.Application.Employees.Commands;
using EmployeeCrud.Web.Application.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Web.Apis;

public static class EmployeeApi
{
    public static void MapEmployees(this RouteGroupBuilder app)
    {
        var group = app.MapGroup("employees");
        group.MapPost("/",SaveEmployee);
        group.MapGet("/",GetEmployees);
        group.MapDelete("/{id}",DeleteEmployee);
    }

    private static async Task<IResult> SaveEmployee([FromServices] IMediator mediator , [FromBody] SaveEmployeeCommand request)
    {
        var response = await mediator.Send(request);
        return Results.Ok(response);
    }

    private static async Task<IResult> GetEmployees([FromServices] IMediator mediator)
    {
        var response = await mediator.Send(new GetEmployeesQuery());
        return Results.Ok(response);
    }

    private static async Task<IResult> DeleteEmployee([FromServices] IMediator mediator,int id)
    {
        var response = await mediator.Send(new DeleteEmployeeCommand() { Id= id});
        return Results.Ok(response);
    }
}
