using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SorteoEstacionamientos.Shared.CapaEntities.Request
{
    public class RequestDTO_Participante
    {
        /*******************************  DATOS ID DEL PARTICIPANTE  *******************************/
        /// <summary>
        /// PK ID Único del Participante
        /// </summary>
        [Key]
        public int IdParticipante { get; set; }

        /// <summary>
        /// FK ID del Rol del Participante { 1 - Administrador, 2 - Usuario Participante }
        /// </summary>
        [Column("partIdRol")]
        public int PartIdRol { get; set; }

        /// <summary>
        /// FK ID del Tipo de Participante { 1 - Nuevo Ingreso (Pre-Boleta), 2 - Inscrito (Boleta), 3 - Maestría, 4 - PAAE }
        /// </summary>
        [Column("partIdTipoParticipante")]
        public int PartIdTipoParticipante { get; set; }

        /*******************************  DATOS PERSONALES  *******************************/
        /// <summary>
        /// Nombre(s) del Participante
        /// </summary>
        [Column("partNombre")]
        [StringLength(100)]
        public string PartNombre { get; set; } = null!;

        /// <summary>
        /// Primer Apellido del Participante
        /// </summary>
        [Column("partPrimerApellido")]
        [StringLength(50)]
        public string PartPrimerApellido { get; set; } = null!;

        /// <summary>
        /// Segundo Apellido del Participante
        /// </summary>
        [Column("partSegundoApellido")]
        [StringLength(50)]
        public string? PartSegundoApellido { get; set; }

        /// <summary>
        /// CURP del Participante de 18 caracteres
        /// </summary>
        [Column("partCURP")]
        [StringLength(18)]
        public string PartCurp { get; set; } = null!;

        /// <summary>
        /// Número de Teléfono Celular del Participante
        /// </summary>
        [Column("partNoTelCelular")]
        [StringLength(10)]
        public string PartNoTelCelular { get; set; } = null!;

        /// <summary>
        /// Correo Electrónico Institucional / Personal
        /// </summary>
        [Column("partEmail")]
        [StringLength(100)]
        public string PartEmail { get; set; } = null!;

        /// <summary>
        /// Contraseña para el acceso a la Plataforma SSOE
        /// </summary>
        [Column("partContraseña")]
        [StringLength(300)]
        public string PartContraseña { get; set; } = null!;

        /*******************************  DATOS LABORALES  *******************************/
        /// <summary>
        /// Número de Empleado en caso de ser PAAE
        /// </summary>
        [Column("partNoEmpleado")]
        [StringLength(15)]
        public string? PartNoEmpleado { get; set; }

        /*******************************  DATOS ACADÉMICOS  *******************************/
        /// <summary>
        /// Número de Boleta en caso de ser Alumno
        /// </summary>
        [Column("partBoleta")]
        [StringLength(10)]
        public string? PartBoleta { get; set; }

        /// <summary>
        /// FK ID de la Carrera / Licenciatura
        /// </summary>
        [Column("partIdCarrera")]
        public int PartIdCarrera { get; set; }

        /// <summary>
        /// FK ID del Último Semestre Cursado { 1 - 10 }
        /// </summary>
        [Column("partIdSemestre")]
        public int PartIdSemestre { get; set; }

        /*******************************  DATOS DEL VEHÍCULO  *******************************/
        /// <summary>
        /// FK ID del Tipo de Vehículo { 1 - Automóvil, 2 - Motocicleta }
        /// </summary>
        [Column("partIdTipoVehiculo")]
        public int PartIdTipoVehiculo { get; set; }

        /// <summary>
        /// FK ID del Estado de la República Mexicana
        /// </summary>
        [Column("partIdEdoRepMexVehiculo")]
        public int PartIdEdoRepMexVehiculo { get; set; }

        /// <summary>
        /// FK ID del Tipo de Placa { 1 - Antiguo/Clásico, 2 - Capacidades diferentes, 3 - Particular, 4 - Público (Taxi / Uber) }
        /// </summary>
        [Column("partIdTipoPlaca")]
        public int PartIdTipoPlaca { get; set; }

        /// <summary>
        /// Placa del Vehículo
        /// </summary>
        [Column("partPlaca")]
        [StringLength(50)]
        public string PartPlaca { get; set; } = null!;

        /// <summary>
        /// Marca del Vehículo
        /// </summary>
        [Column("partMarca")]
        [StringLength(50)]
        public string PartMarca { get; set; } = null!;

        /// <summary>
        /// Modelo del Vehículo
        /// </summary>
        [Column("partModelo")]
        [StringLength(50)]
        public string? PartModelo { get; set; }

        /// <summary>
        /// Versión del Vehículo
        /// </summary>
        [Column("partVersion")]
        [StringLength(50)]
        public string? PartVersion { get; set; }

        /// <summary>
        /// Año del Vehículo
        /// </summary>
        [Column("partAño")]
        public short PartAño { get; set; }

        /// <summary>
        /// Color del Vehículo
        /// </summary>
        [Column("partColor")]
        [StringLength(50)]
        public string PartColor { get; set; } = null!;

        /*******************************  ARCHIVOS  *******************************/
        /// <summary>
        /// Nombre del Archivo de la Credencial Oficial del IPN / INE
        /// </summary>
        [Column("partFileNameCredencialIPNINE")]
        [StringLength(300)]
        public string PartFileNameCredencialIpnine { get; set; } = null!;

        /// <summary>
        /// Nombre del Archivo del Comprobante de Estudios / Horario (Tira de Materias)
        /// </summary>
        [Column("partFileNameComprobanteEstudiosHorario")]
        [StringLength(300)]
        public string PartFileNameComprobanteEstudiosHorario { get; set; } = null!;

        /// <summary>
        /// Nombre del Archivo de la Licencia de Conducir
        /// </summary>
        [Column("partFileNameLicenciaConducir")]
        [StringLength(300)]
        public string PartFileNameLicenciaConducir { get; set; } = null!;

        /// <summary>
        /// Nombre del Archivo de la Tarjeta de Circulación
        /// </summary>
        [Column("partFileNameTarjetaCirculacion")]
        [StringLength(300)]
        public string PartFileNameTarjetaCirculacion { get; set; } = null!;

        /*******************************  OTROS DATOS  *******************************/
        /// <summary>
        /// Fecha y Hora del alta del registro
        /// </summary>
        [Column("partFechaHoraAlta", TypeName = "datetime")]
        public DateTime PartFechaHoraAlta { get; set; }

        /// <summary>
        /// Participante registrado para el Sorteo { 0 - No Registrado, 1 - Registrado }
        /// </summary>
        [Column("partRegistrado", TypeName = "bit(1)")]
        public sbyte PartRegistrado { get; set; }

        /// <summary>
        /// Status del Participante { 0 - Inactivo, 1 - Activo }
        /// </summary>
        [Column("partStatus", TypeName = "bit(1)")]
        public sbyte PartStatus { get; set; }

        [JsonIgnore]
        [InverseProperty("WinIdParticipanteNavigation")]
        public virtual ICollection<RequestDTO_Ganador> MsTbGanadores { get; set; } = new List<RequestDTO_Ganador>();

        [ForeignKey("PartIdCarrera")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_Carrera PartIdCarreraNavigation { get; set; } = null!;

        [ForeignKey("PartIdEdoRepMexVehiculo")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_EdoRepMex PartIdEdoRepMexVehiculoNavigation { get; set; } = null!;

        [ForeignKey("PartIdRol")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_Rol PartIdRolNavigation { get; set; } = null!;

        [ForeignKey("PartIdSemestre")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_Semestre PartIdSemestreNavigation { get; set; } = null!;

        [ForeignKey("PartIdTipoParticipante")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_TipoParticipante PartIdTipoParticipanteNavigation { get; set; } = null!;

        [ForeignKey("PartIdTipoPlaca")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_TipoPlaca PartIdTipoPlacaNavigation { get; set; } = null!;

        [ForeignKey("PartIdTipoVehiculo")]
        [InverseProperty("MsTbParticipantes")]
        public virtual RequestViewModel_TipoVehiculo PartIdTipoVehiculoNavigation { get; set; } = null!;
    }
}
