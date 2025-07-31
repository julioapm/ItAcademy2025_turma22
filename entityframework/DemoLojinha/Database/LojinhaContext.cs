using DemoLojinha.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoLojinha.Database;

public class LojinhaContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    
    public LojinhaContext()
    {
    }

    public LojinhaContext(DbContextOptions<LojinhaContext> opcoes)
    : base(opcoes)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(eb =>
        {
            eb.Property(e => e.Nome).HasMaxLength(30);
            eb.Property(e => e.Email).HasMaxLength(50);
            eb.Property(e => e.Telefone).HasMaxLength(9);
        });

        modelBuilder.Entity<Produto>(eb =>
        {
            eb.Property(e => e.Nome).HasMaxLength(30);
            eb.Property(e => e.Descricao).HasMaxLength(200);
        });
        
        
    }
}