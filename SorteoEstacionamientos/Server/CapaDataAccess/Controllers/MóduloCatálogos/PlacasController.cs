using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacasController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatTipoPlaca>> oResponse = new();

            try
            {
                var list = new List<McCatTipoPlaca>();
                
                if (filterByStatus == 1)
                    list = await _db.McCatTipoPlacas.Where(p => p.IdTipoPlaca == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatTipoPlacas.ToListAsync();

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
            Response<McCatTipoPlaca> oResponse = new();

            try
            {
                var item = await _db.McCatTipoPlacas.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_TipoPlaca model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatTipoPlaca oPlaca = new()
                {
                    IdTipoPlaca = model.IdTipoPlaca,
                    TipoPlaca = model.TipoPlaca
                };

                await _db.McCatTipoPlacas.AddAsync(oPlaca);
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
        public async Task<IActionResult> EditData(RequestViewModel_TipoPlaca model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatTipoPlaca? oPlaca = await _db.McCatTipoPlacas.FindAsync(model.IdTipoPlaca);

                if (oPlaca != null)
                {
                    oPlaca.IdTipoPlaca = oPlaca.IdTipoPlaca;
                    oPlaca.TipoPlaca = oPlaca.TipoPlaca;

                    _db.Entry(oPlaca).State = EntityState.Modified;
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
            Response<object> oResponse = new();

            try
            {
                McCatTipoPlaca? oPlaca = await _db.McCatTipoPlacas.FindAsync(id);

                if (oPlaca != null)
                {
                    oPlaca.IdTipoPlaca = isActivate;
                    _db.Entry(oPlaca).State = EntityState.Modified;
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
