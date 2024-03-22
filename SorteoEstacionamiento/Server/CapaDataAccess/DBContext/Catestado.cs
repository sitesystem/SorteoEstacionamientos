using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("catEstado")]
public partial class Catestado
{
    [Key]
    public int IdEstado { get; set; }

    [Column("EdoNombre")]
    [StringLength(20)]
    public string EdoNombre { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdEstadoNavigation")]
    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
