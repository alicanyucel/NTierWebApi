using Microsoft.EntityFrameworkCore;
using NTier.Entities.Models;
using NTier.Repositories.EFCore.Config;

namespace NTier.Repositories.EFCore.Context;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options) { }
    public DbSet<Book> Books { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfig());
    }
}


