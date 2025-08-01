using System;
using System.Collections.Generic;

namespace DemoEFWebApiScaffold.Models;

public partial class Livro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual Emprestimo? Emprestimo { get; set; }

    public virtual ICollection<Autor> Idautors { get; set; } = new List<Autor>();
}
