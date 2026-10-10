using System;
using System.Collections.Generic;

namespace TAREA.Models;

public partial class Cliente
{
    public int IdClientes { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Telefono { get; set; }
}
