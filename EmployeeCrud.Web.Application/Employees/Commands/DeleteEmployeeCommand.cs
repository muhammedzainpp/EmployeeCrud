using EmployeeCrud.Web.Application.Interfaces;
using EmployeeCrud.Web.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static EmployeeCrud.Web.Application.Helpers.ResponseHelpers;


namespace EmployeeCrud.Web.Application.Employees.Commands;
public class DeleteEmployeeCommand : IRequest<Response<Empty>>
{
    public int Id { get; set; }
}

public class DeleteEmployeeCommandHandler(IAppDbContext context) : IRequestHandler<DeleteEmployeeCommand, Response<Empty>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Response<Empty>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await TryHandleAsyns(request);
    }

    private async Task<Response<Empty>> TryHandleAsyns(DeleteEmployeeCommand request)
    {
        Response<Empty> response;
        try
        {
            var employeeToDelete = await _context.Employees.FindAsync(request.Id)
                ?? default!;

             _context.Employees.Remove(employeeToDelete);

             _context.SaveChanges();

            response = OnSuccess(new Empty());

        }
        catch (Exception ex)
        {
            response = OnError<Empty>(ex);
        }

        return response;
    }
}
