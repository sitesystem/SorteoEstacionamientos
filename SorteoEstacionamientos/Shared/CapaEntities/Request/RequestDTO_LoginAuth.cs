using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaEntities.Request
{
    public class RequestDTO_LoginAuth
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        //[RegularExpression("^[A-Za-z0-9._%+-]*@ipn.mx$", ErrorMessage = "Formato Incorrecto.")]
        public string PartCorreoPersonal { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public string PartContraseña { get; set; } = null!;
    }
}
