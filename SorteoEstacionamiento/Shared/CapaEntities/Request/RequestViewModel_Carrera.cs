using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_Carrera
    {
        [Key]
        public int IdCarrera { get; set; }

        //Este campo es el segundo de nuestro catalogo, y se refiere al nombre de la carrera
        [Column("Carrera")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido.")]
        public string? Carrera {  get; set; }

    }
}
