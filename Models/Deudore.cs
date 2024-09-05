using System;
using System.Collections.Generic;

namespace MSRosaAPI.Models;

public partial class Deudore
{
    public int IdDeudores { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public double? Valor { get; set; }

    public string? Apodo { get; set; }

    public int EstadosDeudaIdEstadosDeuda { get; set; }

    public virtual EstadosDeudum EstadosDeudaIdEstadosDeudaNavigation { get; set; } = null!;
}
