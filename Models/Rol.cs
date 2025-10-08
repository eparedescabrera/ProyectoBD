using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Rol
{
    public int ID_Rol { get; set; }

    public string nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
