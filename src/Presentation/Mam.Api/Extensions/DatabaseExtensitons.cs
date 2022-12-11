using Mam.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Mam.Api.Extensions
{
    public static class DatabaseExtensitons
    {
        public static void DatabaseInitialize(this IApplicationBuilder builder)
        {

            using var serviceScope =
                builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<HotelDbContext>();

            if (context == null) return;
            DatabaseMigration(context);

            context.SaveChanges();
        }

        private static void DatabaseMigration(HotelDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
