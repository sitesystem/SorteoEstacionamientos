using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

[Table("tbGanadore")]
public partial class Tbganadore
{
    [Key]   
    public int IdGanador { get; set; }

    [Column("GanIdParticipante")]
    public int? GanIdParticipante { get; set; }

    [Column("GanSorteoAM")]
    [StringLength(1)]
    public string GanSorteoAm { get; set; } = null!;

    [ForeignKey("GanIdParticipante")]
    [InverseProperty("Tbganadore")]
    public virtual Tbparticipante GanIdParticipanteNavigation { get; set; } = null!;
}
