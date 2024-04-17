using System;
using System.Collections.Generic;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class Catcolore
{
    public int IdColor { get; set; }

    public string ColorNombre { get; set; } = null!;

    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
