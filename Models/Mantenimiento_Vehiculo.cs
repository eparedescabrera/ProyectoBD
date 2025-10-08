using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Mantenimiento_Vehiculo
{
    public int ID_Mantenimiento { get; set; }

    public int ID_Vehiculo { get; set; }

    public DateOnly fecha { get; set; }

    public string tipo { get; set; } = null!;

    public decimal? costo { get; set; }

    public string estado { get; set; } = null!;

    public int? kilometraje { get; set; }

    public virtual Vehiculo ID_VehiculoNavigation { get; set; } = null!;
}
