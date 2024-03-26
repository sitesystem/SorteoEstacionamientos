using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class EscuelasController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatEscuela>> oResponse = new();

            try
            {
                var list = new List<McCatEscuela>();

                if (filterByStatus == 1)
                    list = await _db.McCatEscuelas.Where(e => e.EscStatus == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatEscuelas.ToListAsync();

                if (list == null)
                    return BadRequest(oResponse);

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
            Response<McCatEscuela> oResponse = new();

            try
            {
                var item = await _db.McCatEscuelas.FindAsync(id);
                oResponse.Success = 1;
                oResponse.Data = item;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost]  
        public async Task<IActionResult> AddData(RequestViewModel_Escuela model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatEscuela oEscuela = new()
                {
                    IdEscuela = model.IdEscuela,
                    EscLogo = model.EscLogo,
                    EscNoEscuela = model.EscNoEscuela,
                    EscNombreLargo = model.EscNombreLargo,
                    EscNombreCorto = model.EscNombreCorto,
                    EscFileNameAvisoPrivacidad = model.EscFileNameAvisoPrivacidad,
                    EscFechaFundacion = model.EscFechaFundacion,
                    EscStatus = 1
                };

                await _db.McCatEscuelas.AddAsync(oEscuela);
                await _db.SaveChangesAsync();

                oResponse.Success = 1;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPut]
        public async Task<IActionResult> EditData(RequestViewModel_Escuela model)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatEscuela? oEscuela = await _db.McCatEscuelas.FindAsync(model.IdEscuela);

                if (oEscuela != null)
                {
                    oEscuela.EscLogo = model.EscLogo;
                    oEscuela.EscNoEscuela = model.EscNoEscuela;
                    oEscuela.EscNombreLargo = model.EscNombreLargo;
                    oEscuela.EscNombreCorto = model.EscNombreCorto;
                    oEscuela.EscFileNameAvisoPrivacidad = model.EscFileNameAvisoPrivacidad;
                    oEscuela.EscFechaFundacion = model.EscFechaFundacion;
                    oEscuela.EscStatus = model.EscStatus;

                    _db.Entry(oEscuela).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                oRespuesta.Success = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut("editByIdStatus/{id}/{isActivate}")]
        public async Task<IActionResult> EnableDisableDataById(int id, sbyte isActivate)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatCarrera? oCarrera = await _db.McCatCarreras.FindAsync(id);

                //db.Remove(oPersona);
                if (oCarrera != null)
                {
                    oCarrera.CarrStatus = isActivate;
                    _db.Entry(oCarrera).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                oRespuesta.Success = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
