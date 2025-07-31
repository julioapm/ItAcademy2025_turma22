using DemoLojinha.Models;

namespace DemoLojinha.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ConsultarTodosAsync();
    Task<Produto?> ConsultarPorIdAsync(int id);
}
