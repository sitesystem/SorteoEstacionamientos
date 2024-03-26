using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Server.CapaDataAccess.DBContext;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoRegistrosController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<MsCatPeriodoRegistro>> oResponse = new();
            try
            {
                var list = new List<MsCatPeriodoRegistro>();

                if (filterByStatus == 1)
                    list = await _db.MsCatPeriodoRegistros.Where(c => c.IdPeriodoRegistro == filterByStatus).ToListAsync();
                else
                    list = await _db.MsCatPeriodoRegistros.ToListAsync();

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
            Response<MsCatPeriodoRegistro> oResponse = new();

            try
            {
                var item = await _db.MsCatPeriodoRegistros.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestDTO_PeriodoRegistro model)
        {
            Response<object> oResponse = new();

            try
            {
                MsCatPeriodoRegistro oPeriodoRegistro = new()
                {
                    IdPeriodoRegistro = model.IdPeriodoRegistro,
                    PerFechaHoraInicio = model.PerFechaHoraInicio,
                    PerFechaHoraFin = model.PerFechaHoraFin,
                    PerFileNameConvocatoria = model.PerFileNameConvocatoria,
                    PerStatus = model.PerStatus
                };

                await _db.MsCatPeriodoRegistros.AddAsync(oPeriodoRegistro);
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
        public async Task<IActionResult> EditData(RequestDTO_PeriodoRegistro model)
        {
            Response<object> oRespuesta = new();

            try
            {
                MsCatPeriodoRegistro? oPeriodoRegistro = await _db.MsCatPeriodoRegistros.FindAsync(model.IdPeriodoRegistro);

                if (oPeriodoRegistro != null)
                {
                    oPeriodoRegistro.IdPeriodoRegistro = model.IdPeriodoRegistro;
                    oPeriodoRegistro.PerFechaHoraInicio = model.PerFechaHoraInicio;
                    oPeriodoRegistro.PerFechaHoraFin = model.PerFechaHoraFin;
                    oPeriodoRegistro.PerFileNameConvocatoria = model.PerFileNameConvocatoria;
                    oPeriodoRegistro.PerStatus = model.PerStatus;



                    _db.Entry(oPeriodoRegistro).State = EntityState.Modified;
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
                MsCatPeriodoRegistro? oPeriodoRegistro = await _db.MsCatPeriodoRegistros.FindAsync(id);

                //db.Remove(oPersona);
                if (oPeriodoRegistro != null)
                {
                    oPeriodoRegistro.PerStatus = isActivate;
                    _db.Entry(oPeriodoRegistro).State = EntityState.Modified;
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
