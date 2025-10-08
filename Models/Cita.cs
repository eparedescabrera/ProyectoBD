using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cita
{
    public int ID_Cita { get; set; }

    public int ID_Cliente { get; set; }

    public DateOnly fecha { get; set; }

    public string tipo { get; set; } = null!;

    public string estado { get; set; } = null!;

    public string? observaciones { get; set; }

    public virtual Cliente ID_ClienteNavigation { get; set; } = null!;
}
