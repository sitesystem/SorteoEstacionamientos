using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catTipoParticipante")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatTipoParticipante
{
    /// <summary>
    /// PK ID Único del Tipo de Participante
    /// </summary>
    [Key]
    public int IdTipoParticipante { get; set; }

    /// <summary>
    /// Nombre / Descripción del Tipo de Participante
    /// </summary>
    [Column("tipopartNombre")]
    [StringLength(50)]
    public string TipopartNombre { get; set; } = null!;

    /// <summary>
    /// Status { 0 - Inactivo, 1 - Activo }
    /// </summary>
    [Column("tipopartStatus")]
    public sbyte TipopartStatus { get; set; }

    [JsonIgnore]
    [InverseProperty("PartIdTipoParticipanteNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
