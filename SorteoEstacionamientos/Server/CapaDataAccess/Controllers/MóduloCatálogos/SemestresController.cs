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
    public class SemestresController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatSemestre>> oResponse = new();
            try
            {
                var list = new List<McCatSemestre>();

                if (filterByStatus == 1)
                    list = await _db.McCatSemestres.Where(c => c.IdSemestre == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatSemestres.ToListAsync();

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
            Response<McCatSemestre> oResponse = new();

            try
            {
                var item = await _db.McCatSemestres.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_Semestre model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatSemestre oSemestre = new()
                {
                    IdSemestre = model.IdSemestre,
                    NumSemestre = model.NumSemestre
                };

                await _db.McCatSemestres.AddAsync(oSemestre);
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
        public async Task<IActionResult> EditData(RequestViewModel_Semestre model)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatSemestre? oSemestre = await _db.McCatSemestres.FindAsync(model.IdSemestre);

                if (oSemestre != null)
                {
                    oSemestre.IdSemestre = model.IdSemestre;
                    oSemestre.NumSemestre = model.NumSemestre;

                    _db.Entry(oSemestre).State = EntityState.Modified;
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
                McCatSemestre? oSemestre = await _db.McCatSemestres.FindAsync(id);

                //db.Remove(oPersona);
                if (oSemestre != null)
                {
                    oSemestre.IdSemestre = isActivate;
                    _db.Entry(oSemestre).State = EntityState.Modified;
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
