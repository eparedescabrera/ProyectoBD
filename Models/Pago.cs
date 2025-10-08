using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Pago
{
    public int ID_Pago { get; set; }

    public int ID_ClientePaquete { get; set; }

    public DateOnly fecha { get; set; }

    public decimal monto { get; set; }

    public string? metodo { get; set; }

    public string? estado { get; set; }

    public virtual Cliente_Paquete ID_ClientePaqueteNavigation { get; set; } = null!;
}
