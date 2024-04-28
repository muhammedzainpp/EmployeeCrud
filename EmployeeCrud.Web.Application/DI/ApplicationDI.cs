using EmployeeCrud.Web.Application.Employees.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCrud.Web.Application.DI;
public static class ApplicationDI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
                 cfg.RegisterServicesFromAssembly(typeof(SaveEmployeeCommand).Assembly));
        return services;
    }
}
