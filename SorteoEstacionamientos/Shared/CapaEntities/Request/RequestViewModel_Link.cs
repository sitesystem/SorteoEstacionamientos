using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaEntities.Request
{
    public class RequestViewModel_Link
    {
        /// <summary>
        /// PK ID Único del Enlace Link
        /// </summary>
        [Key]
        public int IdLink { get; set; }

        /// <summary>
        /// Nombre del Enlace o Link
        /// </summary>
        [Column("linkNombre")]
        [StringLength(50)]
        public string LinkNombre { get; set; } = null!;

        /// <summary>
        /// Enlace o Link
        /// </summary>
        [Column("linkEnlace")]
        [StringLength(200)]
        public string LinkEnlace { get; set; } = null!;

        /// <summary>
        /// Estado (1 = Activo, 0 = Inactivo)
        /// </summary>
        [Column("linkStatus", TypeName = "bit(1)")]
        public sbyte LinkStatus { get; set; }
    }
}
