using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamiento.Server.CapaDataAccess.DBContext;
using SorteoEstacionamiento.Shared.CapaEntities.Request;


//using SorteoEstacionamiento.Shared.CapaEntities.Request;
using SorteoEstacionamiento.Shared.CapaEntities.Response;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController(SorteoestacionamientosContext db) : ControllerBase
    {
        private readonly SorteoestacionamientosContext _db = db;


        //Metodo para obtener la informacion mediante el Id
        [HttpGet("filterById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            Response<Catcarrera> oResponse = new();

            try
            {
                var item = await _db.Catcarreras.FindAsync(id);
                oResponse.Success = 1;
                oResponse.Data = item;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }


        //Metido para agregar un valor 
        [HttpPost]
        public async Task<IActionResult> AddData(RequestViewModel_Carrera model)
        {
            Response<object> oResponse = new();

            try
            {
                Catcarrera oCarrera = new()
                {
                    IdCarrera = model.IdCarrera,
                    Carrera = model.Carrera
                };

                await _db.Catcarreras.AddAsync(oCarrera);
                await _db.SaveChangesAsync();

                oResponse.Success = 1;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);

        }

        //Metodo para editar los valores 
        [HttpPut]
        public async Task<IActionResult> EditData(RequestViewModel_Carrera model)
        {
            Response<object> oResponse = new();

            try
            {
                Catcarrera? oCarrera = await _db.Catcarreras.FindAsync(model.IdCarrera);

                if (oCarrera != null)
                {
                    oCarrera.Carrera = model.Carrera;

                    _db.Entry(oCarrera).State = EntityState.Modified;
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
