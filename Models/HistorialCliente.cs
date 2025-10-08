using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class HistorialCliente
{
    public int ID_Historial { get; set; }

    public int ID_Cliente { get; set; }

    public DateOnly? fecha_ultimo_update { get; set; }

    public string? estado_actual { get; set; }

    public int lecciones_completadas { get; set; }

    public int simulacros_realizados { get; set; }

    public int citas_programadas { get; set; }

    public int pagos_realizados { get; set; }

    public virtual Cliente ID_ClienteNavigation { get; set; } = null!;
}
