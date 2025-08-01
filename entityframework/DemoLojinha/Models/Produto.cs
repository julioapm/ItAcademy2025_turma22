namespace DemoLojinha.Models;

public class Produto
{
    public int Id { get; set;}
    public string Nome { get; set;} = null!;
    public string? Descricao { get; set; }
    public int PrecoUnitario { get; set; }
    //relacionamento N-N com Pedido
    public ICollection<Pedido> Pedidos { get; set; } = null!;
    //relacionamento 1-N com Item
    public List<Item> Items { get; set; } = null!;
}