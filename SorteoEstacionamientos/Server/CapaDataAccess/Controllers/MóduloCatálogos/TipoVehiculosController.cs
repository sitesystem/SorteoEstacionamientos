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
    public class TipoVehiculosController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatTipoVehiculo>> oResponse = new();
            try
            {
                var list = new List<McCatTipoVehiculo>();

                if (filterByStatus == 1)
                    list = await _db.McCatTipoVehiculos.Where(c => c.IdTipoVehiculo == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatTipoVehiculos.ToListAsync();

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
            Response<McCatTipoVehiculo> oResponse = new();

            try
            {
                var item = await _db.McCatTipoVehiculos.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_TipoVehiculo model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatTipoVehiculo oTipoVehiculo = new()
                {
                    IdTipoVehiculo = model.IdTipoVehiculo,
                    TipoVehiculo = model.TipoVehiculo
                };

                await _db.McCatTipoVehiculos.AddAsync(oTipoVehiculo);
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
        public async Task<IActionResult> EditData(RequestViewModel_TipoVehiculo model)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatTipoVehiculo? oTipoVehiculo = await _db.McCatTipoVehiculos.FindAsync(model.IdTipoVehiculo);

                if (oTipoVehiculo != null)
                {
                    oTipoVehiculo.IdTipoVehiculo = model.IdTipoVehiculo;
                    oTipoVehiculo.TipoVehiculo = model.TipoVehiculo;
                   

                    _db.Entry(oTipoVehiculo).State = EntityState.Modified;
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
                McCatTipoVehiculo? oTipoVehiculo = await _db.McCatTipoVehiculos.FindAsync(id);

                //db.Remove(oPersona);
                if (oTipoVehiculo != null)
                {
                    oTipoVehiculo.IdTipoVehiculo = isActivate;
                    _db.Entry(oTipoVehiculo).State = EntityState.Modified;
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
