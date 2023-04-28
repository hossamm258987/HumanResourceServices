using Microsoft.EntityFrameworkCore;
using EmployeeServices.Models;

namespace EmployeeServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employies { get; set; }
    }
}
