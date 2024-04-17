using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

using SorteoEstacionamiento.Shared.CapaEntities.Request;
using SorteoEstacionamiento.Shared.CapaEntities.Response;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresController(SorteoestacionamientosContext db) : ControllerBase
    {
        private readonly SorteoestacionamientosContext _db = db;

        //Metodo para obtener la informacion mediante el id
        [HttpGet("filterById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            Response<Catcolore> oResponse = new();

            try
            {
                var item = await _db.Catcolores.FindAsync(id);
                oResponse.Success = 1;
                oResponse.Data = item;
            }
            catch (Exception ex) 
            { 
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }
        
        //Metodo para agregar un valor 
        public async Task<IActionResult> AddData(RequestViewModel_Color model)
        {
            Response<object> oResponse = new();

            try
            {
                Catcolore oColores = new()
                {
                    IdColor = model.IdColor,
                    ColorNombre = model.ColorNombre
                };

                await _db.Catcolores.AddAsync(oColores);
                await _db.SaveChangesAsync();

                oResponse.Success = 1;
            }
            catch(Exception ex) 
            { 
                oResponse.Message = ex.Message; 
            }

            return Ok(oResponse);
        }

        //Metodo para editar los valores
        public async Task<IActionResult> EditData(RequestViewModel_Color model)
        {
            Response<object> oResponse = new();

            try
            {
                Catcolore? oColor = await _db.Catcolores.FindAsync(model.IdColor);

                if (oColor != null) 
                {
                    oColor.ColorNombre = model.ColorNombre;

                    _db.Entry(oColor).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                oResponse.Success = 1;
            }
            catch(Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);   
        }
        

    }
}
