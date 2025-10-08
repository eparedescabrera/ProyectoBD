using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Horario_Instructor
{
    public int ID_HorarioInstructor { get; set; }

    public int ID_Instructor { get; set; }

    public string dia_semana { get; set; } = null!;

    public TimeOnly hora_inicio { get; set; }

    public TimeOnly hora_fin { get; set; }

    public virtual Instructor ID_InstructorNavigation { get; set; } = null!;
}
