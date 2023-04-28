using Microsoft.EntityFrameworkCore;
using SalaryPaymentServices.Models;

namespace SalaryPaymentServices.Data
{
    public class SalaryPaymentDbContext : DbContext
    {
        public SalaryPaymentDbContext(DbContextOptions<SalaryPaymentDbContext> options) : base(options)
        {
        }

        public DbSet<SalaryPayment> SalaryPayments { get; set; }
    }
}
