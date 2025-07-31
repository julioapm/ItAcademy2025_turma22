using DemoLojinha.Models;

namespace DemoLojinha.Repositories;

public interface IClienteRepository
{
    Task<Boolean> ConsultaSeExiste(int id);
    Task<Cliente?> ConsultaPorIdAsync(int id);
}