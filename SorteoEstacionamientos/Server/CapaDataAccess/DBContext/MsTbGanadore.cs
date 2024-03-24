using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MS_tbGanadores")]
[Index("WinIdParticipante", Name = "IdParticipante_idx")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class MsTbGanadore
{
    /// <summary>
    /// PK ID Único del Ganador
    /// </summary>
    [Key]
    public int IdGanador { get; set; }

    /// <summary>
    /// FK ID del Participante
    /// </summary>
    [Column("winIdParticipante")]
    public int WinIdParticipante { get; set; }

    /// <summary>
    /// Fecha y Hora del Sorteo para Corbatines de Estacionamientos
    /// </summary>
    [Column("winFechaHoraSorteo", TypeName = "datetime")]
    public DateTime WinFechaHoraSorteo { get; set; }

    [ForeignKey("WinIdParticipante")]
    [InverseProperty("MsTbGanadores")]
    public virtual MsTbParticipante WinIdParticipanteNavigation { get; set; } = null!;
}
