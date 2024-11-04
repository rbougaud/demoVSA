using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudioVSA.Domain.Entities;

namespace StudioVSA.Data.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable(nameof(Movie));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Author).IsRequired();
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.ReleaseDate).IsRequired();
    }
}
