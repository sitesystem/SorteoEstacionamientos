using System;
using System.Collections.Generic;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class Catestado
{
    public int IdEstado { get; set; }

    public string EdoNombre { get; set; } = null!;

    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
