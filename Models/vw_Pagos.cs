using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class vw_Pagos
{
    public int ID_Pago { get; set; }

    public DateOnly fecha { get; set; }

    public decimal monto { get; set; }

    public int ID_Cliente { get; set; }

    public int ID_Paquete { get; set; }
}
