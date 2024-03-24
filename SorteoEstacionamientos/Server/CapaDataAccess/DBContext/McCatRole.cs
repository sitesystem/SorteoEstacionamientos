using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catRoles")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatRole
{
    /// <summary>
    /// PK ID Único del Rol
    /// </summary>
    [Key]
    public int IdRol { get; set; }

    /// <summary>
    /// Nombre del Rol
    /// </summary>
    [Column("rolNombre")]
    [StringLength(100)]
    public string RolNombre { get; set; } = null!;

    /// <summary>
    /// Descripción detallada del Rol
    /// </summary>
    [Column("rolDescripcion")]
    [StringLength(300)]
    public string? RolDescripcion { get; set; }

    [JsonIgnore]
    [InverseProperty("PartIdRolNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
