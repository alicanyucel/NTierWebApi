using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTier.Entities.Models;

namespace NTier.Repositories.EFCore.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book { Id = 1, Title = "Karagöz ile Hacivat", Price = 75 },
            new Book { Id = 2, Title = "Nutuk", Price = 300 },
            new Book { Id = 3, Title = "Geometri", Price = 400 }
        );
    }
}
