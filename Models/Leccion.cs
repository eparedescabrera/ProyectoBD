using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Leccion
{
    public int ID_Leccion { get; set; }

    public int ID_Cliente { get; set; }

    public int ID_Instructor { get; set; }

    public int? ID_Vehiculo { get; set; }

    public DateOnly fecha { get; set; }

    public TimeOnly hora { get; set; }

    public string tipo { get; set; } = null!;

    public string? calificacion { get; set; }

    public virtual Cliente ID_ClienteNavigation { get; set; } = null!;

    public virtual Instructor ID_InstructorNavigation { get; set; } = null!;

    public virtual Vehiculo? ID_VehiculoNavigation { get; set; }
}
