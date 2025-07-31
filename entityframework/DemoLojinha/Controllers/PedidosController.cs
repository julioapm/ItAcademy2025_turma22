namespace DemoLojinha.Controllers;

using Microsoft.AspNetCore.Mvc;
using DemoLojinha.Repositories;
using DemoLojinha.Models;
using DemoLojinha.Dtos;

[ApiController]
[Route("api/v1/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IClienteRepository clienteRepository;
    private readonly IProdutoRepository produtoRepository;
    private readonly IPedidoRepository pedidoRepository;

    public PedidosController(IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
    {
        this.clienteRepository = clienteRepository;
        this.produtoRepository = produtoRepository;
        this.pedidoRepository = pedidoRepository;
    }

    //GET .../api/v1/pedidos/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PedidoRespostaDTO>> GetPorId(int id)
    {
        var pedido = await pedidoRepository.ConsultarPorIdAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }
        return PedidoRespostaDTO.DeModelParaDto(pedido);
    }

    //POST .../api/v1/pedidos
    [HttpPost]
    public async Task<ActionResult<PedidoRespostaDTO>> PostNovoPedido(CarrinhoRequisicaoDTO carrinho)
    {
        var cliente = await clienteRepository.ConsultaPorIdAsync(carrinho.IdCliente.GetValueOrDefault());
        if (cliente == null)
        {
            return BadRequest();
        }
        if (carrinho.Itens.Count() == 0)
        {
            return BadRequest();
        }
        var itensPedido = new List<Item>();
        foreach (var item in carrinho.Itens)
        {
            var produto = await produtoRepository.ConsultarPorIdAsync(item.IdProduto.GetValueOrDefault());
            if (produto == null)
            {
                return BadRequest();
            }
            var itemPedido = new Item{
                ProdutoId = item.IdProduto.GetValueOrDefault(),
                Quantidade = item.Quantidade.GetValueOrDefault()
            };
            itensPedido.Add(itemPedido);
        }
        var pedido = new Pedido{
            ClienteId = carrinho.IdCliente.GetValueOrDefault(),
            DataEmissao = DateTime.Now,
            Items = itensPedido
        };
        var novoPedido = await pedidoRepository.AdicionarAsync(pedido);
        return CreatedAtAction(
            nameof(GetPorId),
            new { id = novoPedido.Id },
            PedidoRespostaDTO.DeModelParaDto(novoPedido)
        );
    }
}