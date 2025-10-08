using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class Pago
{
    public int ID_Pago { get; set; }

    public int ID_ClientePaquete { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly fecha { get; set; }

    [DataType(DataType.Currency)]
    [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "El monto debe ser mayor o igual a cero.")]
    public decimal monto { get; set; }

    public string? metodo { get; set; }

    public string? estado { get; set; }

    public virtual Cliente_Paquete ID_ClientePaqueteNavigation { get; set; } = null!;
}
