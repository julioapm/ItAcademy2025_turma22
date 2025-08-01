using System;
using System.Collections.Generic;

namespace DemoEFWebApiScaffold.Models;

public partial class Autor
{
    public int Id { get; set; }

    public string Primeironome { get; set; } = null!;

    public string Ultimonome { get; set; } = null!;

    public virtual ICollection<Livro> Idlivros { get; set; } = new List<Livro>();
}
