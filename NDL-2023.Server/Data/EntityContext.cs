using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NDL_2023.Server.Data.Tables;

namespace NDL_2023.Server.Data
{
    public class EntityContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public DbSet<User> Users { get; set; }

        public EntityContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<TrueOrFalse> questions { get; set; }

        public DbSet<User> users { get; set; }

    }
}
