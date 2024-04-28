using EmployeeCrud.Web.Application.Interfaces;
using EmployeeCrud.Web.Shared.Dtos;
using EmployeeCrud.Web.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static EmployeeCrud.Web.Application.Helpers.ResponseHelpers;


namespace EmployeeCrud.Web.Application.Employees.Queries;
public class GetEmployeesQuery : IRequest<Response<IEnumerable<EmployeeDto>>>
{ 
}
public class GetEmployeesQueryHandler(IAppDbContext context) : IRequestHandler<GetEmployeesQuery, Response<IEnumerable<EmployeeDto>>>
{
    private readonly IAppDbContext _context = context;

    public async Task<Response<IEnumerable<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await TryHandleAsync();
    }
    private async Task<Response<IEnumerable<EmployeeDto>>> TryHandleAsync()
    {
        Response<IEnumerable<EmployeeDto>> response;
        try
        {
            var employees = await GetEmployeesAsync();
            response = OnSuccess<IEnumerable<EmployeeDto>>(employees);
        }
        catch (Exception ex)
        {
            response = OnError<IEnumerable<EmployeeDto>>(ex);
        }
        return response;
    }

    private async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
    {
        return await _context
                   .Employees
                   .Select(x => new EmployeeDto
                   {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   })
                   .ToListAsync();
    }
}


