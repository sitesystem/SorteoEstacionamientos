using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_TipoParticipante
    {
        [Key]
        public int IdTipoParticipante { get; set; }

        //Segundo campo nuestra tabla del catalogo TipoParticipante, y se refiere al nombre del tipo
        [Column("TipoParticipante")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public string? TipoParticipante { get; set; }

    }
}
