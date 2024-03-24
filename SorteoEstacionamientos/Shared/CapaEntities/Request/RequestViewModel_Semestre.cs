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
    public class RequestViewModel_Semestre
    {
        /// <summary>
        /// PK ID Único del Semestre
        /// </summary>
        [Key]
        public int IdSemestre { get; set; }

        /// <summary>
        /// Número de Semestre
        /// </summary>
        [Column("numSemestre")]
        [StringLength(50)]
        public string NumSemestre { get; set; } = null!;

        [JsonIgnore]
        [InverseProperty("PartIdSemestreNavigation")]
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
