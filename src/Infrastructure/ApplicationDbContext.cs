using Hobbit.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobbit.src.Infrastructure;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Ambientes> Ambientes { get; set; }
    public DbSet<Armarios> Armarios { get; set; }
    public DbSet<Itens> Itens { get; set; }
    public DbSet<Movimentacoes> Movimentacoes { get; set; }
    public DbSet<Funcionarios> Funcionarios { get; set; }
    public DbSet<RefreshTokens> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionarios>()
            .HasIndex(f => f.Nif)
            .IsUnique();

        modelBuilder.Entity<Armarios>()
            .HasIndex(a => a.Ni)
            .IsUnique();

        modelBuilder.Entity<Itens>()
            .HasIndex(i => i.Ni)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
