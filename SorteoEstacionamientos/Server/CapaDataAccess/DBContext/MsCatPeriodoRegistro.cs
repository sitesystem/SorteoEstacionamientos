using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MS_catPeriodoRegistro")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class MsCatPeriodoRegistro
{
    /// <summary>
    /// PK ID Único del Período de Registro (Calendarización)
    /// </summary>
    [Key]
    public int IdPeriodoRegistro { get; set; }

    /// <summary>
    /// Fecha y Hora de Inicio de Apertura de Registro para el Sorteo
    /// </summary>
    [Column("perFechaHoraInicio", TypeName = "datetime")]
    public DateTime PerFechaHoraInicio { get; set; }

    /// <summary>
    /// Fecha y Hora de Fin de Apertura de Registro para el Sorteo
    /// </summary>
    [Column("perFechaHoraFin")]
    public DateOnly PerFechaHoraFin { get; set; }

    /// <summary>
    /// Nombre del Archivo de la Convocatoria del Período para el Sorteo de Autos y Motos
    /// </summary>
    [Column("perFileNameConvocatoria")]
    [StringLength(300)]
    public string PerFileNameConvocatoria { get; set; } = null!;

    /// <summary>
    /// Estado del Periodo / Calendario de Registro para el Sorteo { 0 - Inactivo, 1 - Activo }
    /// </summary>
    [Column("perStatus")]
    public sbyte PerStatus { get; set; }
}
