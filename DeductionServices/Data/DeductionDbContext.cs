using DeductionServices.Models;
using Microsoft.EntityFrameworkCore;

namespace DeductionServices.Data
{
    public class DeductionDbContext : DbContext
    {
        public DeductionDbContext(DbContextOptions<DeductionDbContext> options) : base(options)
        {
        }

        public DbSet<Deduction> Deductions { get; set; }
    }
}
