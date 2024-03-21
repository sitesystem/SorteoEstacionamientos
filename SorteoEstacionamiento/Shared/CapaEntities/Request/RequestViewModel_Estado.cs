using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_Estado
    {
        [Key]
        public int IdEstado { get; set; }

        //Este campo es el segundo de nuestro catalogo Estados, y se refiere al nombre del estado
        [Column("edoNombre")]
        [StringLength(20)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public string? EdoNombre { get; set; }

    }
}
