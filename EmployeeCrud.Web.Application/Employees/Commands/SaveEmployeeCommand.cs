using EmployeeCrud.Web.Application.Interfaces;
using EmployeeCrud.Web.Domain.Entities;
using EmployeeCrud.Web.Shared.Responses;
using MediatR;
using static EmployeeCrud.Web.Application.Helpers.ResponseHelpers;


namespace EmployeeCrud.Web.Application.Employees.Commands;
public class SaveEmployeeCommand  : IRequest<Response<int>>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public class SaveEmployeeCommandHandler(IAppDbContext context) : IRequestHandler<SaveEmployeeCommand, Response<int>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Response<int>> Handle(SaveEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await TryHandleAsync(request);
    }

    private async Task<Response<int>> TryHandleAsync(SaveEmployeeCommand request)
    {
        Response<int> response;
        try
        {
            var id = await SaveAsync(request);
            response = OnSuccess<int>(id);
        }
        catch (Exception ex)
        {
            response = OnError<int>(ex);
        }
        return response;
    }

    private async Task<int> SaveAsync(SaveEmployeeCommand request)
    {

        var employee = new Employee()
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.Employees.AddAsync(employee);
        _context.SaveChanges();

        return employee.Id;
    }
}