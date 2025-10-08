using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Accion
{
    public int ID_Accion { get; set; }

    public int ID_Usuario { get; set; }

    public DateTime fecha { get; set; }

    public string descripcion { get; set; } = null!;

    public virtual Usuario ID_UsuarioNavigation { get; set; } = null!;
}
