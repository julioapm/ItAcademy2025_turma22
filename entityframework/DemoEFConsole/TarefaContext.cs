using Microsoft.EntityFrameworkCore;

public class TarefaContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("DemoDatabase");
        optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine);
    }
}
