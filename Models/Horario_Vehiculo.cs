using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Horario_Vehiculo
{
    public int ID_HorarioVehiculo { get; set; }

    public int ID_Vehiculo { get; set; }

    public string dia_semana { get; set; } = null!;

    public TimeOnly hora_inicio { get; set; }

    public TimeOnly hora_fin { get; set; }

    public virtual Vehiculo ID_VehiculoNavigation { get; set; } = null!;
}
