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
    public class RequestViewModel_Rol
    {
        /// <summary>
        /// PK ID Único del Rol
        /// </summary>
        [Key]
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre del Rol
        /// </summary>
        [Column("rolNombre")]
        [StringLength(100)]
        public string RolNombre { get; set; } = null!;

        /// <summary>
        /// Descripción detallada del Rol
        /// </summary>
        [Column("rolDescripcion")]
        [StringLength(300)]
        public string? RolDescripcion { get; set; }

        [JsonIgnore]
        [InverseProperty("PartIdRolNavigation")]
        public virtual ICollection<RequestDTO_Participante> MsTbParticipantes { get; set; } = new List<RequestDTO_Participante>();
    }
}
