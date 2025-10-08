using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class vw_Clientes
{
    public int ID_Cliente { get; set; }

    public string nombre { get; set; } = null!;

    public DateOnly fecha_registro { get; set; }
}
