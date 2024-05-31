using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Abstractions;

public interface IDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Event> Events { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}