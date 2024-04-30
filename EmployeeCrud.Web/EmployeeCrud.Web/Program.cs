using EmployeeCrud.Web.Application.Interfaces;
using EmployeeCrud.Web.Client.Pages;
using EmployeeCrud.Web.Components;
using EmployeeCrud.Web.Infra.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeCrud.Web.Application.DI;
using EmployeeCrud.Web.Apis;
using EmployeeCrud.Web.Client.Services.Employees;
using EmployeeCrud.Web.Client.Services.Common;
using EmployeeCrud.Web.Client.Services;
using Blazored.Modal;

namespace EmployeeCrud.Web;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7003") });
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
        builder.Services.AddApplication();

        builder.Services.AddBlazoredModal();

        builder.Services.AddDbContext<IAppDbContext,AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IApiServices, ApiServices>();

        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IModalService, ModalService>();


        var app = builder.Build();
       



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Counter).Assembly);

        var apiGroup = app.MapGroup("/api");
        EndPoints.MapEndPoints(apiGroup);

        app.Run();
    }
}
