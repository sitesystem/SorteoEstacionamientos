using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoEstacionamiento.Shared.CapaEntities.Request
{
    public class RequestViewModel_TbParticipante
    {
        [Key]
        public int IdParticipante { get; set; }
        //Atributos de la tabla TbParticipante////*******************IdTipoParticipante******************************

        [Column("partIdTipoParticipante")]
        [StringLength(11)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido.")]
        public int partIdTipoParticipante { get; set; }
        ////*****************************************CURP*****************************************
        [Column("partCURP")]
        [StringLength(18, ErrorMessage = "El CURP introducido debe ser máximo de 18 caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo CURP requerido.")]
        [MinLength(18, ErrorMessage = "El CURP introducido debe ser mínimo de 18 caracteres.")]
        public string partCURP { get; set; } = null!;
        //*****************************************BOLETA*****************************************
        [Column("partBoleta")]
        [StringLength(10, ErrorMessage = "La BOLETA introducida debe ser máximo de 10 dígitos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo BOLETA requerido.")]
        [MinLength(10, ErrorMessage = "La BOLETA introducida debe ser mínimo de 10 dígitos.")]
        [RegularExpression("^\\d{4}60\\d{4}$", ErrorMessage = "BOLETA Inválida (Formato: xxxx60xxxx).")]
        public string? partBoleta { get; set; }
        //*****************************************NOMBRE*****************************************
        [Column("partNombre")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo NOMBRE(S) requerido.")]
        [RegularExpression("^[a-zA-Z. ]*$", ErrorMessage = "Formato Incorrecto (No se permite acentos o caracteres especiales).")] // NO ADMITE ACENTOS
        public string partNombre { get; set; } = null!;
        //*****************************************PRIMER_AP*****************************************
        [Column("partPrimerAp")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo PRIMER APELLIDO requerido.")]
        [RegularExpression("^[a-zA-Z. ]*$", ErrorMessage = "Formato Incorrecto (No se permite acentos o caracteres especiales).")] // NO ADMITE ACENTOS
        public string partPrimerAp { get; set; } = null!;
        //*****************************************SEGUNDO_AP*****************************************
        [Column("partSegundoAp")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z. ]*$", ErrorMessage = "Formato Incorrecto (No se permite acentos o caracteres especiales).")] // NO ADMITE ACENTOS
        public string? partSegundoAp { get; set; }
        //*****************************************IdCarrera*****************************************

        [Column("partIdCarrera")]
        [StringLength(11)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo CARRERA / LICENCIATURA requerido.")]
        public int? partIdCarrera { get; set; }
        //*****************************************IdSemestre*****************************************
        [Column("partIdSemestre")]
        [StringLength(11)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo SEMESTRE requerido.")]
        public int partIdSemestre { get; set; }
        //*****************************************E-MAIL*****************************************
        [Column("partEmail")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo CORREO ELECTRÓNICO PERSONAL requerido.")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "CORREO inválido. (Formato: xxxxxx@xxx.xx)")]
        public string partEmail { get; set; } = null!;
        //*****************************************NoTelefono*****************************************
        [Column("partNoTelefono")]
        [StringLength(20)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo No. DE CELULAR ACTUAL requerido.")]
        [MinLength(14, ErrorMessage = "El No. DE CELULAR ACTUAL debe ser mínimo de 10 dígitos.")]
        public string partNoTelefono { get; set; } = null!;
        //*****************************************IdEstado*****************************************
        [Column("partIdEstado")]
        [StringLength(11)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo ESTADO requerido.")]
        public int partIdEstado { get; set; }
        //*****************************************IdTipoPlaca*****************************************
        [Column("partIdTipoPlaca")]
        [StringLength(11)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo TIPO DE PLACA requerido.")]
        public int partIdTipoPlaca { get; set; }
        //*****************************************PLACA*****************************************
        [Column("partPlaca")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo PLACA requerido.")]
        public string? partPlaca { get; set; }
        //*****************************************MARCA*****************************************
        [Column("partMarca")]
        [StringLength(50)]
        public string? partMarca { get; set; }
        //*****************************************MODELO*****************************************
        [Column("partModelo")]
        [StringLength(50)]
        public string? partModelo { get; set; }
        //*****************************************IdColor*****************************************
        [Column("partIdColor")]
        [StringLength(11)]
        public int partIdColor { get; set; }
        //*****************************************VERSION*****************************************
        [Column("partVersion")]
        [StringLength(50)]
        public string? partVersion { get; set; }
        //*****************************************AÑO*****************************************
        [Column("partAnio")]
        [StringLength(4)]
        public int partAnio { get; set; }

    }
}