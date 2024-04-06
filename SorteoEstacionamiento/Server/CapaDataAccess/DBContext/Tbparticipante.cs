using System;
using System.Collections.Generic;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

public partial class Tbparticipante
{
    public int IdParticipante { get; set; }

    public int PartIdTipoParticipante { get; set; }

    public string PartCurp { get; set; } = null!;

    public string PartBoleta { get; set; } = null!;

    public string PartNombre { get; set; } = null!;

    public string PartPrimerAp { get; set; } = null!;

    public string PartSegundoAp { get; set; } = null!;

    public int PartIdCarrera { get; set; }

    public int PartIdSemestre { get; set; }

    public string PartEmail { get; set; } = null!;

    public string PartNoTelefono { get; set; } = null!;

    public int PartIdEstado { get; set; }

    public int PartIdTipoPlaca { get; set; }

    public string PartPlaca { get; set; } = null!;

    public string? PartMarca { get; set; }

    public string? PartModelo { get; set; }

    public int PartIdColor { get; set; }

    public string? PartVersion { get; set; }

    public int PartAnio { get; set; }

    public string PartCredencialIpn { get; set; } = null!;

    public string PartTarjetaCirculacion { get; set; } = null!;

    public string PartLicencia { get; set; } = null!;

    public string PartComprobante { get; set; } = null!;

    public ulong PartStatus { get; set; }

    public string? PartTipoVehiculo { get; set; }

    public virtual Catcarrera PartIdCarreraNavigation { get; set; } = null!;

    public virtual Catcolore PartIdColorNavigation { get; set; } = null!;

    public virtual Catestado PartIdEstadoNavigation { get; set; } = null!;

    public virtual Catsemestre PartIdSemestreNavigation { get; set; } = null!;

    public virtual Cattipoparticipante PartIdTipoParticipanteNavigation { get; set; } = null!;

    public virtual Cattipoplaca PartIdTipoPlacaNavigation { get; set; } = null!;

    public virtual ICollection<Tbganadore> Tbganadores { get; set; } = new List<Tbganadore>();
}
