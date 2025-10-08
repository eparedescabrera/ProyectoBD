using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Disponibilidad_Instructor
{
    public int ID_DisponibilidadInstructor { get; set; }

    public int ID_Instructor { get; set; }

    public DateOnly fecha { get; set; }

    public TimeOnly hora_inicio { get; set; }

    public TimeOnly hora_fin { get; set; }

    public string estado { get; set; } = null!;

    public virtual Instructor ID_InstructorNavigation { get; set; } = null!;
}
