using System;
using System.Collections.Generic;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class Tbganadore
{
    public int IdGanador { get; set; }

    public int GanIdParticipante { get; set; }

    public string GanSorteoAm { get; set; } = null!;

    public virtual Tbparticipante GanIdParticipanteNavigation { get; set; } = null!;
}
