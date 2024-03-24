using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

[Table("MC_catTipoVehiculo")]
[MySqlCharSet("latin1")]
[MySqlCollation("latin1_general_cs")]
public partial class McCatTipoVehiculo
{
    /// <summary>
    /// PK ID Único del Tipo de Vehículo { 1 - Auto, 2 - Moto }
    /// </summary>
    [Key]
    public int IdTipoVehiculo { get; set; }

    /// <summary>
    /// Nombre del Tipo de Vehículo
    /// </summary>
    [Column("tipoVehiculo")]
    [StringLength(50)]
    public string TipoVehiculo { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("PartIdTipoVehiculoNavigation")]
    public virtual ICollection<MsTbParticipante> MsTbParticipantes { get; set; } = new List<MsTbParticipante>();
}
