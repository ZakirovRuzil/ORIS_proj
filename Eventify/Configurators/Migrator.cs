using Database;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Configurators;

public static class Migrator
{
    /// <summary>
    /// Применить миграцию к бд
    /// </summary>
    /// <param name="host">хост</param>
    public static async Task MigrateDbAsync(this WebApplication host)
    {
        try
        {
            await using var scope = host.Services.CreateAsyncScope();
            var sp = scope.ServiceProvider;

            await using var db = sp.GetRequiredService<DatabaseContext>();

            await db.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            host.Logger.LogError(e, "Error while migrating the database");
            Environment.Exit(-1);
        }
    }
}