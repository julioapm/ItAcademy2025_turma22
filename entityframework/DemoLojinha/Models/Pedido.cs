namespace DemoLojinha.Models;

public class Pedido
{
    public int Id { get; set; }
    public DateTime DataEmissao { get; set; }
    //relacionamento N-1 com Cliente
    public Cliente Cliente { get; set; } = null!;
    public int ClienteId { get; set; }
    //relacionamento N-N com Produto
    public ICollection<Produto> Produtos { get; set; } = null!;
    //relacionamento 1-N com Item
    public List<Item> Items { get; set; } = null!;
}