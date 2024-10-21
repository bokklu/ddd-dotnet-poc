using Microsoft.EntityFrameworkCore;
using POC.DDD.Infra.DTOs;

namespace POC.DDD.Infra
{
    public class BusinessContext : DbContext
    {
        public DbSet<BusinessDto> Businesses { get; set; }

        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options)
        {
        }
    }
}
