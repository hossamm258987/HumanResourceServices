using Microsoft.EntityFrameworkCore;
using DepartmentServices.Models;

namespace DepartmentServices.Data
{
    public class DeptDbContext : DbContext
    {
        public DeptDbContext(DbContextOptions<DeptDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
    }
}
