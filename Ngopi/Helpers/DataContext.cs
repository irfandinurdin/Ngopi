using Microsoft.EntityFrameworkCore;
using Ngopi.Models;

namespace Ngopi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<DetailProduct> DetailProducts { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Processing> Processings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoastLevel> RoastLevels { get; set; }
        public DbSet<Species> Specieses { get; set; }
        public DbSet<Tasted> Tasteds { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
