using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Instructor
{
    public int ID_Instructor { get; set; }

    public string nombre { get; set; } = null!;

    public string? licencia { get; set; }

    public virtual ICollection<Disponibilidad_Instructor> Disponibilidad_Instructor { get; set; } = new List<Disponibilidad_Instructor>();

    public virtual ICollection<Horario_Instructor> Horario_Instructor { get; set; } = new List<Horario_Instructor>();

    public virtual ICollection<Leccion> Leccion { get; set; } = new List<Leccion>();

    public virtual ICollection<Simulacro> Simulacro { get; set; } = new List<Simulacro>();
}
