using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;
using System.Reflection.Metadata.Ecma335;


namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController(DBSorteoParkingContext db) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatLink>> oResponse = new();

            try
            {
                var list = new List<McCatLink>();

                if (filterByStatus == 1)
                    list = await _db.McCatLinks.Where(l => l.LinkStatus == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatLinks.ToListAsync();

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
            Response<McCatLink> oResponse = new();

            try
            {
                var item = await _db.McCatLinks.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_Link model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatLink oLink = new()
                {
                    IdLink = model.IdLink,
                    LinkNombre = model.LinkNombre,
                    LinkEnlace = model.LinkEnlace,
                    LinkStatus = 1
                };

                await _db.McCatLinks.AddAsync(oLink);
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
        public async Task<IActionResult> EditData(RequestViewModel_Link model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatLink? oLink = await _db.McCatLinks.FindAsync(model.IdLink);

                if (oLink != null)
                {
                    oLink.IdLink = model.IdLink;
                    oLink.LinkNombre = model.LinkNombre;
                    oLink.LinkEnlace = model.LinkEnlace;
                    oLink.LinkStatus = model.LinkStatus;

                    _db.Entry(oLink).State = EntityState.Modified;
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

        [HttpPut("editByIdStatus/{id}/{isActivate}")]
        public async Task<IActionResult> EnableDisableDataById(int id, sbyte isActivate)
        {
            Response<McCatLink> oResponse = new();

            try
            {
                McCatLink? oLink = await _db.McCatLinks.FindAsync(id);

                if (oLink != null) 
                {
                    oLink.LinkStatus = isActivate;
                    _db.Entry(oLink).State = EntityState.Modified;
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
