using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SorteoEstacionamientos.Shared.CapaEntities.Request
{
    public class RequestViewModel_TipoVehiculo
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
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
