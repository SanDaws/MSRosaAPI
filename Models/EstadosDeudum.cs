using System;
using System.Collections.Generic;

namespace MSRosaAPI.Models;

public partial class EstadosDeudum
{
    public int IdEstadosDeuda { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Deudore> Deudores { get; set; } = new List<Deudore>();
}
