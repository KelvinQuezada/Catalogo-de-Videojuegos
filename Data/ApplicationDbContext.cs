using CatalogoVideojuegos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVideojuegos.Data;

/// <summary>
/// Contexto de Entity Framework Core. Representa la sesión con la base de
/// datos PostgreSQL y expone un DbSet por cada entidad del modelo.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Videojuego> Videojuegos { get; set; }

    public DbSet<Plataforma> Plataformas { get; set; }

    public DbSet<Desarrolladora> Desarrolladoras { get; set; }

    public DbSet<Genero> Generos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación 1:N — Genero (principal) → Videojuego (dependiente).
        // Se restringe el borrado en cascada para no eliminar videojuegos
        // cuando se elimina un género que todavía los agrupa.
        modelBuilder.Entity<Videojuego>()
            .HasOne(v => v.Genero)
            .WithMany(g => g.Videojuegos)
            .HasForeignKey(v => v.GeneroId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación 1:N — Desarrolladora (principal) → Videojuego (dependiente).
        modelBuilder.Entity<Videojuego>()
            .HasOne(v => v.Desarrolladora)
            .WithMany(d => d.Videojuegos)
            .HasForeignKey(v => v.DesarrolladoraId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
