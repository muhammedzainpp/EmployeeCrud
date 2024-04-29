using EmployeeCrud.Web.Application.Interfaces;
using EmployeeCrud.Web.Domain.Entities;
using EmployeeCrud.Web.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static EmployeeCrud.Web.Application.Helpers.ResponseHelpers;


namespace EmployeeCrud.Web.Application.Employees.Commands;
public class SaveEmployeeCommand  : IRequest<Response<int>>
{
    public int Id { get; set; }
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
        
        int id;

        if (request.Id == 0)
        {
            id = await CreateAsync(request);
            return id;
        }
        else
        {
            id = await UpdateAsync(request);
            return id;
        }
 
    }

    private async Task<int> CreateAsync(SaveEmployeeCommand request)
    {

        var employee = new Employee()
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.Employees.AddAsync(employee);
        _context.SaveChanges();
        return  employee.Id;
    }
    private async Task<int> UpdateAsync(SaveEmployeeCommand request)
    {

        var employee = await _context
         .Employees
         .FirstOrDefaultAsync(e => e.Id == request.Id) ?? default! ;
         employee.Name = request.Name;
         employee.Description = request.Description;
         _context.SaveChanges();
         return employee.Id;
    }
}