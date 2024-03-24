using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catCarreras")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatCarrera
{
    /// <summary>
    /// PK ID Único de la Carrera / Licenciatura
    /// </summary>
    [Key]
    public int IdCarrera { get; set; }

    /// <summary>
    /// Clave de la Carrera / Licenciatura
    /// </summary>
    [Column("carrClave")]
    [StringLength(20)]
    public string? CarrClave { get; set; }

    /// <summary>
    /// Nombre de la Carrera / Licenciatura
    /// </summary>
    [Column("carrNombre")]
    [StringLength(300)]
    public string CarrNombre { get; set; } = null!;

    /// <summary>
    /// Estado (1 = Activo, 0 = Inactivo)
    /// </summary>
    [Column("carrStatus")]
    public sbyte CarrStatus { get; set; }

    [JsonIgnore]
    [InverseProperty("PartIdCarreraNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
