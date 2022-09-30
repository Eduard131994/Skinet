using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationDatabaseExtension
    {
        public async static Task<WebApplication> SeedAndMigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
                await dataContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(dataContext);
            }
            return app;
        }

    }
}