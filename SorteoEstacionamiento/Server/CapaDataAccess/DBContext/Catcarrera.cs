using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("catCarreras")]
public partial class Catcarrera
{
    [Key]
    public int IdCarrera { get; set; }

    [Column("Carrera")]
    [StringLength(50)]
    public string? Carrera { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdCarreraNavigation")]
    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
