using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;
using SorteoEstacionamientos.Shared.CapaTools;
using SorteoEstacionamientos.Shared;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloRegistros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController(DBSorteoParkingContext db, IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
		private readonly DBSorteoParkingContext _db = db;
		private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
		private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

		[HttpGet("filterByStatus/{filterByStatus}")]
		public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
		{
			Response<List<MsTbParticipante>> oResponse = new();

			try
			{
				var list = new List<MsTbParticipante>();

				if (filterByStatus == 1)
					list = await _db.MsTbParticipantes.Where(p => p.PartStatus.Equals(filterByStatus)).ToListAsync();
				//   .OrderByDescending(x => x.Id)
				//   .Skip((actualPage - 1) * Utilities.REGISTERSPERPAGE)
				//   .Take(Utilities.REGISTERSPERPAGE)
				//   .ToList();
				else
					list = await _db.MsTbParticipantes.ToListAsync();

				oResponse.Success = 1;
				oResponse.Data = list;
			}
			catch (Exception ex)
			{
				oResponse.Message = ex.Message;
			}
			return Ok(oResponse);
		}

		[HttpGet("filterById/{id}")]
		public async Task<IActionResult> GetDataById(int id)
		{
			Response<MsTbParticipante> oResponse = new();

			try
			{
				var item = await _db.MsTbParticipantes.FindAsync(id);
				oResponse.Success = 1;
				oResponse.Data = item;
			}
			catch (Exception ex)
			{
				oResponse.Message = ex.Message;
			}

			return Ok(oResponse);
		}

		[HttpGet("filterByEmailCURP/{correo}/{curp}")]
		public async Task<IActionResult> ValidateByEmailCURP(string correo, string curp)
		{
			Response<MsTbParticipante> oResponse = new();

			try
			{
				var list = await _db.MsTbParticipantes
									.Where(p => p.PartCurp == correo || p.PartCurp == curp)
									.Where(p => p.PartStatus == 1)
									.FirstOrDefaultAsync();
				if (list is null)
					oResponse.Success = 1;
				else
					oResponse.Data = list;
			}
			catch (Exception ex)
			{
				oResponse.Message = ex.Message;
			}

			return Ok(oResponse);
		}

		[HttpPost]
		public async Task<IActionResult> AddData(RequestDTO_Participante model)
		{
			Response<object> oResponse = new();
			CreatedAtActionResult oCreatedAtActionResult;

			try
			{
				MsTbParticipante oParticipante = new()
				{
					// DATOS ID DEL PARTICIPANTE
					IdParticipante = model.IdParticipante,
					PartIdRol = model.PartIdRol,
					PartIdTipoParticipante = model.PartIdTipoParticipante,
					// DATOS PERSONALES
					PartNombre = model.PartNombre.ToUpper(),
					PartPrimerApellido = model.PartPrimerApellido.ToUpper(),
					PartSegundoApellido = model.PartSegundoApellido == null ? null : model.PartSegundoApellido.ToUpper(),
					PartCurp = model.PartCurp.ToUpper(),
					PartNoTelCelular = model.PartNoTelCelular,
					PartEmail = model.PartEmail,
					PartContraseña = Encrypt.GetSHA256(model.PartContraseña),
					// DATOS ACADÉMICOS
					PartBoleta = model.PartBoleta,
					PartNoEmpleado = model.PartNoEmpleado,
					PartIdCarrera = model.PartIdCarrera,
					PartIdSemestre = model.PartIdSemestre,
					// DATOS AUTOMOVIL
					PartIdTipoVehiculo = model.PartIdTipoVehiculo,
					PartIdEdoRepMexVehiculo = model.PartIdEdoRepMexVehiculo,
					PartIdTipoPlaca = model.PartIdTipoPlaca,
					PartPlaca = model.PartPlaca,
					PartMarca = model.PartMarca,
					PartModelo = model.PartModelo,
					PartVersion = model.PartVersion,
					PartAño = model.PartAño,
					PartColor = model.PartColor,
					// OTROS DATOS
					PartFileNameCredencialIpnine = model.PartFileNameCredencialIpnine,
					PartFileNameComprobanteEstudiosHorario = model.PartFileNameComprobanteEstudiosHorario,
					PartFileNameLicenciaConducir = model.PartFileNameLicenciaConducir,
					PartFileNameTarjetaCirculacion = model.PartFileNameTarjetaCirculacion,
					PartFechaHoraAlta = DateTime.Now,
					PartRegistrado = model.PartRegistrado,
					PartStatus = model.PartStatus,
					// DATOS FK NAVIGATION
					PartIdCarreraNavigation = null,
					PartIdEdoRepMexVehiculoNavigation = null,
					PartIdRolNavigation = null,
					PartIdSemestreNavigation = null,
					PartIdTipoParticipanteNavigation = null,
					PartIdTipoPlacaNavigation = null,
					PartIdTipoVehiculoNavigation = null
				};

				await _db.MsTbParticipantes.AddAsync(oParticipante);
				await _db.SaveChangesAsync();

				oResponse.Success = 1;

				oCreatedAtActionResult = CreatedAtAction(nameof(AddData), new { id = oParticipante.IdParticipante }, oParticipante);
				oResponse.Message = oParticipante.IdParticipante.ToString(); // PK ID Único del Usuario Creado o dado de Alta
			}
			catch (Exception ex)
			{
				oResponse.Message = ex.Message;
			}

			return Ok(oResponse);
		}

		[HttpPut]
		public async Task<IActionResult> EditData(RequestDTO_Participante model)
		{
			Response<object> oResponse = new();

			try
			{
				MsTbParticipante? oParticipante = await _db.MsTbParticipantes.FindAsync(model.IdParticipante);

				if (oParticipante != null)
				{
					// DATOS ID DEL USUARIO
					oParticipante.PartIdRol = model.PartIdRol;
					oParticipante.PartIdTipoParticipante = model.PartIdTipoParticipante;
					// DATOS PERSONALES
					oParticipante.PartNombre = model.PartNombre.ToUpper();
					oParticipante.PartPrimerApellido = model.PartPrimerApellido.ToUpper();
					oParticipante.PartSegundoApellido = model.PartSegundoApellido?.ToUpper();
					oParticipante.PartCurp = model.PartCurp.ToUpper();
					oParticipante.PartNoTelCelular = model.PartNoTelCelular;
					oParticipante.PartEmail = model.PartEmail;
					oParticipante.PartContraseña = model.PartContraseña;
					// DATOS ACADÉMICOS
					oParticipante.PartBoleta = model.PartBoleta;
					oParticipante.PartNoEmpleado = model.PartNoEmpleado;
					oParticipante.PartIdCarrera = model.PartIdCarrera;
					oParticipante.PartIdSemestre = model.PartIdSemestre;
					// DATOS AUTOMOVIL
					oParticipante.PartIdTipoVehiculo = model.PartIdTipoVehiculo;
					oParticipante.PartIdEdoRepMexVehiculo = model.PartIdEdoRepMexVehiculo;
					oParticipante.PartIdTipoPlaca = model.PartIdTipoPlaca;
					oParticipante.PartPlaca = model.PartPlaca;
					oParticipante.PartMarca = model.PartMarca;
					oParticipante.PartModelo = model.PartModelo;
					oParticipante.PartVersion = model.PartVersion;
					oParticipante.PartAño = model.PartAño;
					oParticipante.PartColor = model.PartColor;
					// DATOS DE LOS ARCHIVOS QUE SE VAN A SUBIR A LA PLATAFORMA
					oParticipante.PartFileNameCredencialIpnine = model.PartFileNameCredencialIpnine;
					oParticipante.PartFileNameComprobanteEstudiosHorario = model.PartFileNameComprobanteEstudiosHorario;
					oParticipante.PartFileNameLicenciaConducir = model.PartFileNameLicenciaConducir;
					oParticipante.PartFileNameTarjetaCirculacion = model.PartFileNameTarjetaCirculacion;
					oParticipante.PartFechaHoraAlta = DateTime.UtcNow;
					oParticipante.PartRegistrado = model.PartRegistrado;
					oParticipante.PartStatus = 1;
					// DATOS FK NAVIGATION
					oParticipante.PartIdCarreraNavigation = null;
					oParticipante.PartIdEdoRepMexVehiculoNavigation = null;
					oParticipante.PartIdRolNavigation = null;
					oParticipante.PartIdSemestreNavigation = null;
					oParticipante.PartIdTipoParticipanteNavigation = null;
					oParticipante.PartIdTipoPlacaNavigation = null;
					oParticipante.PartIdTipoVehiculoNavigation = null;

					_db.Entry(oParticipante).State = EntityState.Modified;
					await _db.SaveChangesAsync();
				}

				oResponse.Success = 1;
			}
			catch (Exception ex)
			{
				oResponse.Message = ex.Message;
			}

			return Ok(oResponse);
		}

		[HttpPut("editByIdStatus/{id}/{isActivate}")]
		public async Task<IActionResult> EnableDisableDataById(int id, sbyte isActivate)
		{
			Response<object> oResponse = new();

			try
			{
				MsTbParticipante? oParticipante = await _db.MsTbParticipantes.FindAsync(id);

				if (oParticipante != null)
				{
					oParticipante.PartStatus = isActivate;
					_db.Entry(oParticipante).State = EntityState.Modified;
					await _db.SaveChangesAsync();
				}

				oResponse.Success = 1;
			}
			catch (Exception ex)
			{
				oResponse.Message = ex.Message;
			}

			return Ok(oResponse);
		}

	}
}
