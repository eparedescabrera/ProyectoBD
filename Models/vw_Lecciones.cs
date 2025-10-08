using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class vw_Lecciones
{
    public int ID_Leccion { get; set; }

    public DateOnly fecha { get; set; }

    public int ID_Cliente { get; set; }

    public int ID_Instructor { get; set; }

    public int? ID_Vehiculo { get; set; }

    public string tipo { get; set; } = null!;
}
