using EntityFrameworkSP_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSP_Demo.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Product { get; set; }
    }
}
