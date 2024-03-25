using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosRepMexicanaController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatEstadosRepMexicana>> oResponse = new();

            try
            {
                var list = new List<McCatEstadosRepMexicana>();

                if (filterByStatus == 1)
                    list = await _db.McCatEstadosRepMexicanas.Where(e => e.IdEdoRepMex == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatEstadosRepMexicanas.ToListAsync();

                if(list == null)
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
            Response<McCatEstadosRepMexicana> oResponse = new();

            try
            {
                var item = await _db.McCatEstadosRepMexicanas.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_EdoRepMex model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatEstadosRepMexicana oEdoRepMex = new()
                {
                    IdEdoRepMex = model.IdEdoRepMex,
                    EdoNombre = model.EdoNombre
                };

                await _db.McCatEstadosRepMexicanas.AddAsync(oEdoRepMex);
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
        public async Task<IActionResult> EditData(RequestViewModel_EdoRepMex model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatEstadosRepMexicana? oEdoRepMex = await _db.McCatEstadosRepMexicanas.FindAsync(model.IdEdoRepMex);

                if (oEdoRepMex != null)
                {
                    oEdoRepMex.IdEdoRepMex = model.IdEdoRepMex;
                    oEdoRepMex.EdoNombre = model.EdoNombre;

                    _db.Entry(oEdoRepMex).State = EntityState.Modified;
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


        [HttpPut("filterByIdStatus/{id}/{isActivate}")]
        public async Task<IActionResult> EnableDisableDataById(int id, sbyte isActivate)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatEstadosRepMexicana? oEdoRepMex = await _db.McCatEstadosRepMexicanas.FindAsync(id);
                if (oEdoRepMex != null)
                {
                    oEdoRepMex.IdEdoRepMex = isActivate;
                    _db.Entry(oEdoRepMex).State = EntityState.Modified;
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
