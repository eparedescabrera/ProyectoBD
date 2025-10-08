using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Disponibilidad_Vehiculo
{
    public int ID_DisponibilidadVehiculo { get; set; }

    public int ID_Vehiculo { get; set; }

    public DateOnly fecha { get; set; }

    public TimeOnly hora_inicio { get; set; }

    public TimeOnly hora_fin { get; set; }

    public string estado { get; set; } = null!;

    public virtual Vehiculo ID_VehiculoNavigation { get; set; } = null!;
}
