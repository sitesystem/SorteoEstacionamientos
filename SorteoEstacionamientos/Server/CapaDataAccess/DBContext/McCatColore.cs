using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catColores")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatColore
{
    /// <summary>
    /// PK ID Único del Color
    /// </summary>
    [Key]
    public int IdColor { get; set; }

    /// <summary>
    /// Nombre del Color
    /// </summary>
    [Column("colorNombre")]
    [StringLength(50)]
    public string ColorNombre { get; set; } = null!;
}
