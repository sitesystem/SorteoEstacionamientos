using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

using SorteoEstacionamiento.Shared.CapaEntities.Request;
using SorteoEstacionamiento.Shared.CapaEntities.Response;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class SemestresController(SorteoestacionamientosContext db) : ControllerBase
    {
        private readonly SorteoestacionamientosContext _db = db;

        //Metodo para obtener la infromacion mediante id
        [HttpGet("filterById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            Response<Catsemestre> oResponse = new();

            try
            {
                var item = await _db.Catsemestres.FindAsync(id);
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
        [HttpPost]
        public async Task<IActionResult> AddData(RequestViewModel_Semestre model)
        {
            Response<object> oResponse = new();

            try
            {
                Catsemestre oSemestre = new()
                {
                    IdSemestre = model.IdSemestre,
                    Semestre = model.Semestre
                };

                await _db.Catsemestres.AddAsync(oSemestre);
                await _db.SaveChangesAsync();

                oResponse.Success = 1;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            Ok(oResponse);
        }

        //Metodo para editar valores
        [HttpPut]
        public async Task<IActionResult> EditData(RequestViewModel_Semestre model)
        {
            Response<object> oResponse = new();

            try
            {
                Catsemestre? oSemestre = await _db.Catsemestres.FindAsync(model.IdSemestre);
            
                if(oSemestre != null)
                {
                    oSemestre.Semestre = model.Semestre;

                    _db.Entry(oSemestre).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                oResponse.Success = 1;
            }
            catch(Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            Ok(oResponse);  
        }

    }
}
