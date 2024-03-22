using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_TbGanador
    {
        [Key]
        public int IdGanador { get; set; }
        //Atributos de la tabla TbGanador
        [Column("ganIdParticipante")]
        [StringLength(11)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public string? ganIdParticipante { get; set; }
        //*******************************************************************************
        [Column("ganSorteoAM")]
        [StringLength(1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public string? ganSorteoAM { get; set; }
    }
}
