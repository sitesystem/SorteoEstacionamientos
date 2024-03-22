using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("catColore")]
public partial class Catcolore
{
    [Key]
    public int IdColor { get; set; }

    [Column("ColorNombre")]
    [StringLength(50)]
    public string? ColorNombre { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdColorNavigation")]
    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
