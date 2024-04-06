using System;
using System.Collections.Generic;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class Cattipoplaca
{
    public int IdTipoPlaca { get; set; }

    public string TipoPlaca { get; set; } = null!;

    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
