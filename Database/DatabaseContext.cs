using Core.Abstractions;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IDbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    public DbSet<Event> Events { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await SaveChangesAsync(true, cancellationToken);
}