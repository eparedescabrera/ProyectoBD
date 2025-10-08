using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Usuario
{
    public int ID_Usuario { get; set; }

    public string nombre { get; set; } = null!;

    public string correo { get; set; } = null!;

    public int ID_Rol { get; set; }

    public virtual ICollection<Accion> Accion { get; set; } = new List<Accion>();

    public virtual Rol ID_RolNavigation { get; set; } = null!;
}
