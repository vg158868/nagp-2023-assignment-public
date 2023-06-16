using Microsoft.EntityFrameworkCore;
using NAGP.DevOps.Data.Entities;

namespace NAGP.DevOps.Data
{
    public class DevOpsDbContext : DbContext
    {
        public DevOpsDbContext()
        {
        }

        public DevOpsDbContext(DbContextOptions<DevOpsDbContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}