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
    }
}
