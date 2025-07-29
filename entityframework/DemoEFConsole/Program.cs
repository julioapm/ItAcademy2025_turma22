using System.Collections.Immutable;

Console.WriteLine("Iniciando o programa...");

using (var contexto = new TarefaContext())
{
    Console.WriteLine("Adicionando uma nova tarefa...");
    contexto.Tarefas.Add(new Tarefa
    {
        Nome = "Estudar Entity Framework",
        Descricao = "Ler a documentação e praticar exemplos.",
        Concluida = false
    });
    contexto.Tarefas.Add(new Tarefa
    {
        Nome = "Revisar código",
        Descricao = "Fazer revisão do código escrito na semana.",
        Concluida = true
    });
    contexto.SaveChanges();

    Console.WriteLine("Consultando todas as tarefas...");
    var todasTarefas = contexto.Tarefas.ToImmutableList();
    foreach (var tarefa in todasTarefas)
    {
        Console.WriteLine($"- {tarefa.Nome} (Concluída: {tarefa.Concluida})");
    }

    Console.WriteLine("Atualizando uma tarefa...");
    var umaTarefa = contexto.Tarefas.Find(2L);
    if (umaTarefa != null)
    {
        umaTarefa.Concluida = false;
    }
    contexto.SaveChanges();
}

Console.WriteLine("Finalizando o programa...");