using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FindAMovie.Models;

namespace FindAMovie.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(entity => 
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Series_Title).IsRequired().HasMaxLength(200);
            entity.Property(m => m.Genre).HasMaxLength(100);
            entity.Property(m => m.IMDB_Rating).HasColumnType("float").HasPrecision(3, 1);
        });
    }   
}
