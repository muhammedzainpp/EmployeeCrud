using EmployeeCrud.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Web.Application.Interfaces;
public interface IAppDbContext
{
    DbSet<Employee> Employees { get; set; }

    int SaveChanges();
}
