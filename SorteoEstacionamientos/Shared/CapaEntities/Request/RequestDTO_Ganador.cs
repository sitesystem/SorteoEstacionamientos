using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaEntities.Request
{
    public class RequestDTO_Ganador
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
        public virtual RequestDTO_Participante WinIdParticipanteNavigation { get; set; } = null!;
    }
}
