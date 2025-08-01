using DemoLojinha.Repositories;
using DemoLojinha.Models;
using Microsoft.EntityFrameworkCore;
using DemoLojinha.Database;

namespace DemoLojinha.Services;

public class PedidoRepositoryEF : IPedidoRepository
{
    private readonly LojinhaContext contexto;

    public PedidoRepositoryEF(LojinhaContext contexto)
    {
        this.contexto = contexto;
    }

    public async Task<Pedido> AdicionarAsync(Pedido pedido)
    {
        await contexto.Pedidos.AddAsync(pedido);
        await contexto.SaveChangesAsync();
        return pedido;
    }

    public Task<Pedido?> ConsultarPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}