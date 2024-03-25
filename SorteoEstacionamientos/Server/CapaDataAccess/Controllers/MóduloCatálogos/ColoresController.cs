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
    public class ColoresController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task <IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatColore>> oResponse = new();
            try
            {
                var list = new List<McCatColore>();

                if (filterByStatus == 1)
                    list = await _db.McCatColores.Where(c => c.IdColor == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatColores.ToListAsync();

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
            Response<McCatColore> oResponse = new();

            try
            {
                var item = await _db.McCatColores.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_Color model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatColore oColor = new()
                {
                    IdColor = model.IdColor,
                    ColorNombre = model.ColorNombre
                };

                await _db.McCatColores.AddAsync(oColor);
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
        public async Task<IActionResult> EditData(RequestViewModel_Color model)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatColore? oColor = await _db.McCatColores.FindAsync(model.IdColor);

                if (oColor != null)
                {
                    oColor.IdColor = model.IdColor;
                    oColor.ColorNombre = model.ColorNombre;

                    _db.Entry(oColor).State = EntityState.Modified;
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
                McCatColore? oColor = await _db.McCatColores.FindAsync(id);

                //db.Remove(oPersona);
                if (oColor != null)
                {
                    oColor.IdColor = isActivate;
                    _db.Entry(oColor).State = EntityState.Modified;
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
