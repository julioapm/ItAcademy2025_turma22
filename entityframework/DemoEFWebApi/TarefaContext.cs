using Microsoft.EntityFrameworkCore;

public class TarefaContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; } = null!;

    public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
    {
    }

    public TarefaContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tarefa>()
            .Property(t => t.Nome)
            .HasMaxLength(30);
    }
}