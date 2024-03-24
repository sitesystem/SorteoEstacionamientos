using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catTipoPlaca")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatTipoPlaca
{
    /// <summary>
    /// PK ID Único del Tipo de Placa
    /// </summary>
    [Key]
    public int IdTipoPlaca { get; set; }

    /// <summary>
    /// Tipo de la Placa { Antiguo/Clásico, Capacidades diferentes, Particular, Público (Taxi, Uber) }
    /// </summary>
    [Column("tipoPlaca")]
    [StringLength(30)]
    public string TipoPlaca { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdTipoPlacaNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
