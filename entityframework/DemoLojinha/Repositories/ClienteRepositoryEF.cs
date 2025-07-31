using DemoLojinha.Database;
using DemoLojinha.Models;
using DemoLojinha.Repositories;
using Microsoft.EntityFrameworkCore;

public class ClienteRepositoryEF : IClienteRepository
{
    private readonly LojinhaContext contexto;

    public ClienteRepositoryEF(LojinhaContext contexto)
    {
        this.contexto = contexto;
    }

    public Task<Cliente?> ConsultaPorIdAsync(int id)
    {
        return contexto.Clientes
            .Where(c => c.Id == id)
            .SingleOrDefaultAsync();
    }

    public Task<bool> ConsultaSeExiste(int id)
    {
        return contexto.Clientes
            .AnyAsync(c => c.Id == id);
    }
}