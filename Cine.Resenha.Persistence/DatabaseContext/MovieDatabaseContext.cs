using Cine.Resenha.Domain;
using Cine.Resenha.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cine.Resenha.Persistence.DatabaseContext;

public class MovieDatabaseContext : DbContext
{
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieDatabaseContext).Assembly);
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}