using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NDL_2023.Server.Data.Tables;

namespace NDL_2023.Server.Data
{
    public class EntityContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public EntityContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InitializeDefaultData()
        {
            List<TrueOrFalse> defaultValues = new()
            {
                new TrueOrFalse()
                {
                    statement = "Planter des arbres contribue significativement à la réduction des émissions de gaz à effet de serre.",
                    true_or_false = true,
                    additional_explanation = "Les arbres absorbent le dioxyde de carbone (CO2) pendant la photosynthèse, aidant ainsi à réduire les concentrations de gaz à effet de serre."
                },
                new TrueOrFalse()
                {
                    statement = "Planter des arbres contribue significativement à la réduction des émissions de gaz à effet de serre.",
                    true_or_false = true,
                    additional_explanation = "Les arbres absorbent le dioxyde de carbone (CO2) pendant la photosynthèse, aidant ainsi à réduire les concentrations de gaz à effet de serre."
                }
            };

            foreach (var value in defaultValues)
            {
                if (!TrueOrFalses.Where(t => t.statement == value.statement).Any())
                {
                    TrueOrFalses.Add(value);
                }
            }

            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<TrueOrFalse> TrueOrFalses { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
