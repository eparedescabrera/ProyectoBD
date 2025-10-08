using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cliente
{
    public int ID_Cliente { get; set; }

    public string nombre { get; set; } = null!;

    public string? contacto { get; set; }

    public DateOnly fecha_registro { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Cliente_Paquete> Cliente_Paquete { get; set; } = new List<Cliente_Paquete>();

    public virtual HistorialCliente? HistorialCliente { get; set; }

    public virtual ICollection<Leccion> Leccion { get; set; } = new List<Leccion>();

    public virtual ICollection<Simulacro> Simulacro { get; set; } = new List<Simulacro>();
}
