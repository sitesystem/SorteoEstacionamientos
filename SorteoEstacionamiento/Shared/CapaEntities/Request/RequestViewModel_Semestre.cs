using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_Semestre
    {
        [Key]
        public int IdSemestre { get; set; }

        //Este campo es el segundo de nuestro catalogo Semestre, y se refiere al numero de semestre
        [Column("Semestre")]
        [Required]
        public int Semestre { get; set; }

    }
}
