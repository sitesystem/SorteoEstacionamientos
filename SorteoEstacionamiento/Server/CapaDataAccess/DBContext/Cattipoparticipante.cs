using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("catTipoParticipante")]
public partial class Cattipoparticipante
{
    [Key]
    public int IdTipoParticipante { get; set; }

    [Column("TipoParticipante")]
    [StringLength(50)]
    public string TipoParticipante { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdTipoParticipanteNavigation")]
    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
