using EmployeeCrud.Web.Application.Employees.Commands;
using EmployeeCrud.Web.Application.ValidationBehaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCrud.Web.Application.DI;
public static class ApplicationDI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ApplicationDI).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(SaveEmployeeCommand).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        //.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}
