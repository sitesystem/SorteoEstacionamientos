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
    public class RequestViewModel_TipoParticipante
    {
        /// <summary>
        /// PK ID Único del Tipo de Participante
        /// </summary>
        [Key]
        public int IdTipoParticipante { get; set; }

        /// <summary>
        /// Nombre / Descripción del Tipo de Participante
        /// </summary>
        [Column("tipopartNombre")]
        [StringLength(50)]
        public string TipopartNombre { get; set; } = null!;

        /// <summary>
        /// Status { 0 - Inactivo, 1 - Activo }
        /// </summary>
        [Column("tipopartStatus", TypeName = "bit(1)")]
        public sbyte TipopartStatus { get; set; }

        [JsonIgnore]
        [InverseProperty("PartIdTipoParticipanteNavigation")]
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
