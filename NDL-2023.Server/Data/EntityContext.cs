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
                    statement = "Les énergies renouvelables ne peuvent pas répondre à la demande mondiale en énergie.",
                    true_or_false = false,
                    additional_explanation = "Les technologies énergétiques renouvelables ont le potentiel de répondre à une grande partie de la demande mondiale en énergie, avec des améliorations continues."
                },
                new TrueOrFalse()
                {
                    statement = "Le réchauffement climatique n'affecte que les régions proches de l'équateur.",
                    true_or_false = false,
                    additional_explanation = "Le changement climatique a des impacts mondiaux, affectant les régions équatoriales ainsi que les pôles et d'autres zones."
                },
                new TrueOrFalse()
                {
                    statement = "L'utilisation du plastique contribue au réchauffement climatique en libérant des gaz à effet de serre lors de sa production.",
                    true_or_false = true,
                    additional_explanation = "La production de plastique, à partir de combustibles fossiles, libère des gaz à effet de serre, contribuant au changement climatique."
                },
                new TrueOrFalse()
                {
                    statement = "Les émissions de méthane, un puissant gaz à effet de serre, proviennent principalement des ruminants tels que les vaches.",
                    true_or_false = true,
                    additional_explanation = "La digestion des ruminants produit du méthane, contribuant au réchauffement climatique."
                },
                new TrueOrFalse()
                {
                    statement = "La fonte des glaciers n'affecte que l'élévation du niveau de la mer, sans autres conséquences.",
                    true_or_false = false,
                    additional_explanation = "La fonte des glaciers affecte également les écosystèmes locaux, l'approvisionnement en eau et peut entraîner des phénomènes météorologiques extrêmes."
                },
                new TrueOrFalse()
                {
                    statement = "Les océans absorbent plus de chaleur que la terre, contribuant ainsi à la régulation du climat.",
                    true_or_false = true,
                    additional_explanation = "Les océans jouent un rôle crucial dans la régulation thermique de la planète en absorbant et en redistribuant la chaleur."
                },
                new TrueOrFalse()
                {
                    statement = "Les changements climatiques n'ont aucun impact sur la biodiversité.",
                    true_or_false = false,
                    additional_explanation = "Les changements climatiques peuvent perturber les habitats naturels, entraînant des changements dans la distribution des espèces et des risques d'extinction."
                },
                new TrueOrFalse()
                {
                    statement = "Le recours à l'énergie nucléaire est une solution entièrement propre et sans émissions de gaz à effet de serre.",
                    true_or_false = false,
                    additional_explanation = "Bien que l'énergie nucléaire émette peu de CO2 lors de la production d'électricité, la chaîne d'approvisionnement et la gestion des déchets posent des défis environnementaux."
                },
                new TrueOrFalse()
                {
                    statement = "La diminution de la consommation de viande rouge a un impact significatif sur la réduction des émissions de gaz à effet de serre.",
                    true_or_false = true,
                    additional_explanation = "La production de viande rouge est associée à des émissions importantes de méthane et d'autres gaz à effet de serre, réduire la consommation peut contribuer à la lutte contre le changement climatique."
                },
                new TrueOrFalse()
                {
                    statement = "Les émissions de méthane provenant des décharges sont négligeables par rapport à celles des élevages de bétail.",
                    true_or_false = false,
                    additional_explanation = "Les décharges émettent une quantité significative de méthane, contribuant au changement climatique."
                },
                new TrueOrFalse()
                {
                    statement = "La hausse des températures n'a aucun lien avec les phénomènes météorologiques extrêmes.",
                    true_or_false = false,
                    additional_explanation = "Le changement climatique intensifie les phénomènes météorologiques extrêmes tels que les ouragans, les inondations et les vagues de chaleur."
                },
                new TrueOrFalse()
                {
                    statement = "Les énergies renouvelables ne peuvent pas répondre à la demande mondiale en énergie.",
                    true_or_false = false,
                    additional_explanation = "Les technologies énergétiques renouvelables ont le potentiel de répondre à une grande partie de la demande mondiale en énergie, avec des améliorations continues."
                },
                new TrueOrFalse()
                {
                    statement = "La disparition des glaciers n'affecte que les régions montagneuses, sans impact sur les basses terres.",
                    true_or_false = false,
                    additional_explanation = "La disparition des glaciers peut affecter les basses terres en modifiant les régimes hydrologiques et en augmentant le risque d'inondations."
                },
                new TrueOrFalse()
                {
                    statement = "Les activités humaines n'ont aucun impact sur l'acidification des océans.",
                    true_or_false = false,
                    additional_explanation = "Les émissions de CO2 d'origine humaine contribuent à l'acidification des océans, menaçant la vie marine."
                },
                new TrueOrFalse()
                {
                    statement = "La reforestation est une solution équivalente à la conservation des forêts existantes pour contrer le changement climatique.",
                    true_or_false = false,
                    additional_explanation = "La conservation des forêts existantes est cruciale car les arbres matures stockent plus de carbone que les jeunes arbres."
                },
                new TrueOrFalse()
                {
                    statement = "L'utilisation de l'énergie nucléaire génère des déchets qui restent dangereux pendant des milliers d'années.",
                    true_or_false = true,
                    additional_explanation = "Bien que l'énergie nucléaire ait peu d'émissions de CO2, la gestion des déchets nucléaires pose des défis à long terme."
                },
                new TrueOrFalse()
                {
                    statement = "Les océans absorbent tous les gaz à effet de serre, contribuant ainsi à les éliminer de l'atmosphère.",
                    true_or_false = false,
                    additional_explanation = "Les océans absorbent principalement le dioxyde de carbone, mais pas d'autres gaz à effet de serre comme le méthane."
                },
                new TrueOrFalse()
                {
                    statement = "La réduction des émissions de gaz à effet de serre n'affecte que le climat, sans impact sur la qualité de l'air.",
                    true_or_false = false,
                    additional_explanation = "La réduction des émissions améliore la qualité de l'air en réduisant les polluants atmosphériques liés aux combustibles fossiles."
                },
                new TrueOrFalse()
                {
                    statement = "La gestion durable des forêts ne contribue pas significativement à la lutte contre le changement climatique.",
                    true_or_false = false,
                    additional_explanation = "La gestion durable des forêts, y compris la sylviculture, aide à maintenir la capacité des forêts à stocker le carbone."
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
