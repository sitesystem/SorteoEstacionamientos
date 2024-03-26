using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatRole>> oResponse = new();

            try
            {
                var list = new List<McCatRole>();

                if (filterByStatus == 1)
                    list = await _db.McCatRoles.Where(r => r.IdRol == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatRoles.ToListAsync();

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
            Response<McCatRole> oResponse = new();

            try
            {
                var item = await _db.McCatRoles.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_Rol model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatRole oRol = new()
                {
                    IdRol = model.IdRol,
                    RolNombre = model.RolNombre,
                    RolDescripcion = model.RolDescripcion
                };

                await _db.McCatRoles.AddAsync(oRol);
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
        public async Task<IActionResult> EditData(RequestViewModel_Rol model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatRole? oRol = await _db.McCatRoles.FindAsync(model.IdRol);
                
                if (oRol != null)
                {
                    oRol.IdRol = model.IdRol;
                    oRol.RolNombre = model.RolNombre;
                    oRol.RolDescripcion = model.RolDescripcion;

                    _db.Entry(oRol).State = EntityState.Modified;
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
            Response<McCatRole> oResponse = new();

            try
            {
                McCatRole? oRol = await _db.McCatRoles.FindAsync(id);

                if (oRol != null)
                {
                    oRol.IdRol = isActivate;
                    _db.Entry(oRol).State = EntityState.Modified;
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
