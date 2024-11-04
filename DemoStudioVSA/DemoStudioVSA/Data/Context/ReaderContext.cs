using Microsoft.EntityFrameworkCore;
using StudioVSA.Domain.Entities;

namespace StudioVSA.Data.Context;

public class ReaderContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public ReaderContext(DbContextOptions<ReaderContext> options) : base(options)
    {
    }
}
