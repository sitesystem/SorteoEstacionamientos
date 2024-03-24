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
    public class RequestViewModel_EdoRepMex
    {
        /// <summary>
        /// PK ID Único del Estado de la República Mexicana
        /// </summary>
        [Key]
        public int IdEdoRepMex { get; set; }

        /// <summary>
        /// Estado de la República Mexicana (32 Estados)
        /// </summary>
        [Column("edoNombre")]
        [StringLength(45)]
        public string EdoNombre { get; set; } = null!;

        [JsonIgnore]
        [InverseProperty("PartIdEdoRepMexVehiculoNavigation")]
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
