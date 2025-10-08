using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Vehiculo
{
    public int ID_Vehiculo { get; set; }

    public string placa { get; set; } = null!;

    public string? tipo { get; set; }

    public string? transmision { get; set; }

    public string? estado { get; set; }

    public virtual ICollection<Disponibilidad_Vehiculo> Disponibilidad_Vehiculo { get; set; } = new List<Disponibilidad_Vehiculo>();

    public virtual ICollection<Horario_Vehiculo> Horario_Vehiculo { get; set; } = new List<Horario_Vehiculo>();

    public virtual ICollection<Leccion> Leccion { get; set; } = new List<Leccion>();

    public virtual ICollection<Mantenimiento_Vehiculo> Mantenimiento_Vehiculo { get; set; } = new List<Mantenimiento_Vehiculo>();

    public virtual ICollection<Simulacro> Simulacro { get; set; } = new List<Simulacro>();
}
