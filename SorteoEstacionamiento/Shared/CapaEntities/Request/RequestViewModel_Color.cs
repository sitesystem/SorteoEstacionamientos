using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_Color
    {
        //Definimos cual el la PK de nuestra clase
        [Key]
        public int IdColor {  get; set; }

        //Este campo es el segundo de nuestro catalogo, y se refiere al nombre de la carrera
        [Column("ColorNombre")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido")]
        public string? ColorNombre { get; set; }

    }
}
