using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catEstadosRepMexicana")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_general_ci")]
public partial class McCatEstadosRepMexicana
{
    /// <summary>
    /// PK ID Único del Estado de la República Mexicana
    /// </summary>
    [Key]
    public int IdEdoRepMex { get; set; }

    /// <summary>
    /// Estado de la República Mexicana (32 Estados)
    /// </summary>
    [Column("edoNombre")]
    [StringLength(45)]
    public string EdoNombre { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdEdoRepMexVehiculoNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
