using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("tbParticipante")]
public partial class Tbparticipante
{
    [Key]
    public int IdParticipante { get; set; }

    [Column("partIdTipoParticipante")]
    public int PartIdTipoParticipante { get; set; }

    [Column("partCurp")]
    [StringLength(20)]
    public string PartCurp { get; set; } = null!;

    [Column("partBoleta")]
    [StringLength(15)]
    public string PartBoleta { get; set; } = null!;

    [Column("partNombre")]
    [StringLength(50)]
    public string PartNombre { get; set; } = null!;

    [Column("partPrimerAp")]
    [StringLength(50)]
    public string PartPrimerAp { get; set; } = null!;

    [Column("partSegundoAp")]
    [StringLength(50)]
    public string PartSegundoAp { get; set; } = null!;

    [Column("partIdCarrera")]
    public int PartIdCarrera { get; set; }

    [Column("partIdSemestre")]
    public int PartIdSemestre { get; set; }

    [Column("partEmail")]
    [StringLength(50)]
    public string PartEmail { get; set; } = null!;

    [Column("partNoTelefono")]
    [StringLength(20)]
    public string PartNoTelefono { get; set; } = null!;

    [Column("partIdEstado")]
    public int PartIdEstado { get; set; }

    [Column("partIdTipoPlaca")]
    public int PartIdTipoPlaca { get; set; }

    [Column("partPlaca")]
    [StringLength(50)]
    public string PartPlaca { get; set; } = null!;

    [Column("partMarca")]
    [StringLength(50)]
    public string? PartMarca { get; set; }

    [Column("partModelo")]
    [StringLength(50)]
    public string? PartModelo { get; set; }

    [Column("partIdColor")]
    public int PartIdColor { get; set; }

    [Column("partVersion")]
    [StringLength(50)]
    public string? PartVersion { get; set; }

    [Column("partAño")]
    public int PartAnio { get; set; }

    [Column("partCredencialIpn")]
    [StringLength(50)]
    public string PartCredencialIpn { get; set; } = null!;

    [Column("partTarjetaCirculacion")]
    [StringLength(50)]
    public string PartTarjetaCirculacion { get; set; } = null!;

    [Column("partLicencia")]
    [StringLength(50)]
    public string PartLicencia { get; set; } = null!;

    [Column("partComprobante")]
    [StringLength(50)] 
    public string PartComprobante { get; set; } = null!;

    [Column("partStatus")]
    public ulong PartStatus { get; set; }

    [Column("partTipoVehiculo")]
    [StringLength(45)]
    public string? PartTipoVehiculo { get; set; }

    [ForeignKey("PartIdCarrera")]
    [InverseProperty("Tbparticipante")]
    public virtual Catcarrera PartIdCarreraNavigation { get; set; } = null!;

    [ForeignKey("PartIdColor")]
    [InverseProperty("Tbparticipante")]
    public virtual Catcolore PartIdColorNavigation { get; set; } = null!;

    [ForeignKey("PartIdEstado")]
    [InverseProperty("Tbparticipante")]
    public virtual Catestado PartIdEstadoNavigation { get; set; } = null!;

    [ForeignKey("PartIdSemestre")]
    [InverseProperty("Tbparticipante")]
    public virtual Catsemestre PartIdSemestreNavigation { get; set; } = null!;

    [ForeignKey("PartIdTipoParticipante")]
    [InverseProperty("Tbparticipante")]
    public virtual Cattipoparticipante PartIdTipoParticipanteNavigation { get; set; } = null!;

    [ForeignKey("PartIdTipoPlaca")]
    [InverseProperty("Tbparticipante")]
    public virtual Cattipoplaca PartIdTipoPlacaNavigation { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("GanIdParticipanteNavigation")]
    public virtual ICollection<Tbganadore> Tbganadores { get; set; } = new List<Tbganadore>();
}
