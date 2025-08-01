using DemoLojinha.Database;
using DemoLojinha.Models;
using DemoLojinha.Repositories;
using Microsoft.EntityFrameworkCore;

public class ProdutoRepositoryEF : IProdutoRepository
{
    private readonly LojinhaContext contexto;
    
    public ProdutoRepositoryEF(LojinhaContext contexto)
    {
        this.contexto = contexto;
    }

    public Task<Produto?> ConsultarPorIdAsync(int id)
    {
        return contexto.Produtos.FindAsync(id).AsTask();
    }

    public async Task<IEnumerable<Produto>> ConsultarTodosAsync()
    {
        return await contexto.Produtos
                .OrderBy(p => p.Nome)
                .ToListAsync();
    }
}