namespace DemoLojinha.Controllers;

using Microsoft.AspNetCore.Mvc;
using DemoLojinha.Repositories;
using DemoLojinha.Dtos;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogoController : ControllerBase
{
    private readonly IProdutoRepository produtoRepository;

    public CatalogoController(IProdutoRepository produtoRepository)
    {
        this.produtoRepository = produtoRepository;
    }

    //GET .../api/v1/catalogo
    [HttpGet]
    public async Task<IEnumerable<ProdutoCatalogoRespostaDTO>> GetTodos()
    {
        var produtos = await produtoRepository.ConsultarTodosAsync();
        return produtos.Select(ProdutoCatalogoRespostaDTO.DeModelParaDto);
    }
}