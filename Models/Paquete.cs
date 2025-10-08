using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Paquete
{
    public int ID_Paquete { get; set; }

    public string nombre { get; set; } = null!;

    public string? tipo { get; set; }

    public decimal precio { get; set; }

    public string? descripcion { get; set; }

    public virtual ICollection<Cliente_Paquete> Cliente_Paquete { get; set; } = new List<Cliente_Paquete>();
}
