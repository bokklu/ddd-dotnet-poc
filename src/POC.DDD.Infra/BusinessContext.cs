using Microsoft.EntityFrameworkCore;
using POC.DDD.Infra.Entities;

namespace POC.DDD.Infra
{
    public class BusinessContext : DbContext
    {
        public DbSet<BusinessEntity> Businesses { get; set; }

        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options)
        {
        }
    }
}
