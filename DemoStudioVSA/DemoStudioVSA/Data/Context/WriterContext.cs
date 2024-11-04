using Microsoft.EntityFrameworkCore;
using StudioVSA.Domain.Entities;

namespace StudioVSA.Data.Context;

public class WriterContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public WriterContext(DbContextOptions<WriterContext> options) : base(options)
    {
    }
}
