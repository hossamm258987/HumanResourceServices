using Microsoft.EntityFrameworkCore;
using AttendaceServices.Models;

namespace AttendaceServices.Data
{
    public class AttendaceDbContext : DbContext
    {
        public AttendaceDbContext(DbContextOptions<AttendaceDbContext> options) : base(options)
        {
        }

        public DbSet<Attendace> Attendaces { get; set; }

    }
}
