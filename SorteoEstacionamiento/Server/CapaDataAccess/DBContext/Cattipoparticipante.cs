using System;
using System.Collections.Generic;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class Cattipoparticipante
{
    public int IdTipoParticipante { get; set; }

    public string TipoParticipante { get; set; } = null!;

    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
