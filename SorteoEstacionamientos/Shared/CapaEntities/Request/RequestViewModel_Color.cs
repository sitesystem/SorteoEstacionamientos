using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaEntities.Request
{
    public class RequestViewModel_Color
    {
        /// <summary>
        /// PK ID Único del Color
        /// </summary>
        [Key]
        public int IdColor { get; set; }

        /// <summary>
        /// Nombre del Color
        /// </summary>
        [Column("colorNombre")]
        [StringLength(50)]
        public string ColorNombre { get; set; } = null!;
    }
}
