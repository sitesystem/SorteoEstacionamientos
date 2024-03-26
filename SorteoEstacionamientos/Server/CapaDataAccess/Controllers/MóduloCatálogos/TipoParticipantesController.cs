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
    public class TipoParticipantesController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatTipoParticipante>> oResponse = new();
            try
            {
                var list = new List<McCatTipoParticipante>();

                if (filterByStatus == 1)
                    list = await _db.McCatTipoParticipantes.Where(c => c.IdTipoParticipante == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatTipoParticipantes.ToListAsync();

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
            Response<McCatTipoParticipante> oResponse = new();

            try
            {
                var item = await _db.McCatTipoParticipantes.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_TipoParticipante model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatTipoParticipante oTipoParticipante = new()
                {
                    IdTipoParticipante = model.IdTipoParticipante,
                    TipopartNombre = model.TipopartNombre,
                    TipopartStatus = model.TipopartStatus
                };

                await _db.McCatTipoParticipantes.AddAsync(oTipoParticipante);
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
        public async Task<IActionResult> EditData(RequestViewModel_TipoParticipante model)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatTipoParticipante? oTipoParticipante = await _db.McCatTipoParticipantes.FindAsync(model.IdTipoParticipante);

                if (oTipoParticipante != null)
                {
                    oTipoParticipante.IdTipoParticipante = model.IdTipoParticipante;
                    oTipoParticipante.TipopartNombre = model.TipopartNombre;
                    oTipoParticipante.TipopartStatus = model.TipopartStatus;

                    _db.Entry(oTipoParticipante).State = EntityState.Modified;
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
                McCatTipoParticipante? oTipoParticipante = await _db.McCatTipoParticipantes.FindAsync(id);

                //db.Remove(oPersona);
                if (oTipoParticipante != null)
                {
                    oTipoParticipante.TipopartStatus = isActivate;
                    _db.Entry(oTipoParticipante).State = EntityState.Modified;
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
