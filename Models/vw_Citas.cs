using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class vw_Citas
{
    public int ID_Cita { get; set; }

    public DateOnly fecha { get; set; }

    public int ID_Cliente { get; set; }

    public string tipo { get; set; } = null!;

    public string estado { get; set; } = null!;
}
