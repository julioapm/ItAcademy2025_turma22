using DemoLojinha.Models;

namespace DemoLojinha.Repositories;

public interface IPedidoRepository
{
    Task<Pedido> AdicionarAsync(Pedido pedido);
    Task<Pedido?> ConsultarPorIdAsync(int id);
}
