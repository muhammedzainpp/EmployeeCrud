using EmployeeCrud.Web.Application.Interfaces;
using EmployeeCrud.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Web.Infra.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<Employee> Employees { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
