using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catSemestres")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatSemestre
{
    /// <summary>
    /// PK ID Único del Semestre
    /// </summary>
    [Key]
    public int IdSemestre { get; set; }

    /// <summary>
    /// Número de Semestre
    /// </summary>
    [Column("numSemestre")]
    [StringLength(50)]
    public string NumSemestre { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdSemestreNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
