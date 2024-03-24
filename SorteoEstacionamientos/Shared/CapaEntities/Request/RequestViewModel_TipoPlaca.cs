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
    public class RequestViewModel_TipoPlaca
    {
        /// <summary>
        /// PK ID Único del Tipo de Placa
        /// </summary>
        [Key]
        public int IdTipoPlaca { get; set; }

        /// <summary>
        /// Tipo de la Placa { Antiguo/Clásico, Capacidades diferentes, Particular, Público (Taxi, Uber) }
        /// </summary>
        [Column("tipoPlaca")]
        [StringLength(30)]
        public string TipoPlaca { get; set; } = null!;

        [JsonIgnore]
        [InverseProperty("PartIdTipoPlacaNavigation")]
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
