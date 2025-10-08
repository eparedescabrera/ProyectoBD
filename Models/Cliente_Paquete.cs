using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class Cliente_Paquete
{
    public int ID_ClientePaquete { get; set; }

    public int ID_Cliente { get; set; }

    public int ID_Paquete { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly fecha_contratacion { get; set; }

    public virtual Cliente ID_ClienteNavigation { get; set; } = null!;

    public virtual Paquete ID_PaqueteNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
