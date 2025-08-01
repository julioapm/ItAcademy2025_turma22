using System;
using System.Collections.Generic;

namespace DemoEFWebApiScaffold.Models;

public partial class Emprestimo
{
    public int Id { get; set; }

    public DateOnly? Datadevolucao { get; set; }

    public DateOnly? Dataretirada { get; set; }

    public bool Entregue { get; set; }

    public int Idlivro { get; set; }

    public virtual Livro IdNavigation { get; set; } = null!;
}
