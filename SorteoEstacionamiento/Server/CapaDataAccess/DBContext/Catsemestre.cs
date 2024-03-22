using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("catSemestre")]
public partial class Catsemestre
{
    [Key]
    public int IdSemestre { get; set; }

    [Column("Semestre")]
    public int Semestre { get; set; }

    [JsonIgnore]
    [InverseProperty("PartIdSemestreNavigation")]
    public virtual ICollection<Tbparticipante> Tbparticipantes { get; set; } = new List<Tbparticipante>();
}
