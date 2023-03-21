using Microsoft.EntityFrameworkCore;
using src.Ingredients.Ingredients.API.Helper;
using src.Ingredients.Ingredients.API.Repository;

namespace src.Ingredients.Ingredients.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(DatabaseConnectionHelper.GetConnectionString(configuration));
            });
        }
        public static void MigrateDatabase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<RepositoryContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}