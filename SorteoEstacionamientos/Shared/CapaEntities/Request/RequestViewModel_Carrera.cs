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
    public class RequestViewModel_Carrera
    {
        /// <summary>
        /// PK ID Único de la Carrera / Licenciatura
        /// </summary>
        [Key]
        public int IdCarrera { get; set; }

        /// <summary>
        /// Clave de la Carrera / Licenciatura
        /// </summary>
        [Column("carrClave")]
        [StringLength(20)]
        public string? CarrClave { get; set; }

        /// <summary>
        /// Nombre de la Carrera / Licenciatura
        /// </summary>
        [Column("carrNombre")]
        [StringLength(300)]
        public string CarrNombre { get; set; } = null!;

        /// <summary>
        /// Estado (1 = Activo, 0 = Inactivo)
        /// </summary>
        [Column("carrStatus")]
        public sbyte CarrStatus { get; set; }

        [JsonIgnore]
        [InverseProperty("PartIdCarreraNavigation")]
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
