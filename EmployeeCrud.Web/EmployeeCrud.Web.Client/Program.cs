using Blazored.Modal;
using EmployeeCrud.Web.Client.Services;
using EmployeeCrud.Web.Client.Services.Common;
using EmployeeCrud.Web.Client.Services.Employees;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredModal();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7003") });
builder.Services.AddScoped<IApiServices, ApiServices>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IModalService, ModalService>();


await builder.Build().RunAsync();
