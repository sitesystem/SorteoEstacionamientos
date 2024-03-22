using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_TipoPlaca
    {
        [Key]
        public int IdTipoPlaca { get; set; }

        //Segundo campo nuestra tabla del catalogo TipoPlaca, y se refiere al nombre del tipo
        [Column("tipoPlaca")]
        [StringLength(30)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public string? tipoPlaca { get; set; }

    }
}
