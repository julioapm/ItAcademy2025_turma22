using DemoLojinha.Models;

namespace DemoLojinha.Dtos;

public class PedidoRespostaDTO
{
    public int Id { get; set; }
    public string DataEmissao { get; set; } = null!;
    public string NomeCliente { get; set; } = null!;
    public string ValorTotal {get; set; } = null!;
    public IEnumerable<ItemRespostaDTO> Itens { get; set; } = null!;

    public static PedidoRespostaDTO DeModelParaDto(Pedido pedido)
    {
        return new PedidoRespostaDTO {
            Id = pedido.Id,
            DataEmissao = pedido.DataEmissao.ToShortDateString(),
            NomeCliente = pedido.Cliente.Nome,
            ValorTotal = $"{pedido.Items.Sum(item => item.Quantidade*item.Produto.PrecoUnitario)/100M:C}",
            Itens = pedido.Items.Select(ItemRespostaDTO.DeModelParaDto)
        };
    }
}

public class ItemRespostaDTO
{
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; } = null!;
    public string ValorUnitario { get; set; } = null!;
    public int Quantidade { get; set; }
    public string SubTotal {get; set; } = null!;

    public static ItemRespostaDTO DeModelParaDto(Item item)
    {
        return new ItemRespostaDTO {
            IdProduto = item.ProdutoId,
            NomeProduto = item.Produto.Nome,
            ValorUnitario = $"{item.Produto.PrecoUnitario/100M:C}",
            Quantidade = item.Quantidade,
            SubTotal = $"{item.Quantidade*item.Produto.PrecoUnitario/100M:C}"
        };
    }
}