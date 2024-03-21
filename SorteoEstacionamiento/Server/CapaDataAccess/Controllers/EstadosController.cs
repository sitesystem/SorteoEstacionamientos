using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

using SorteoEstacionamiento.Shared.CapaEntities.Request;
using SorteoEstacionamiento.Shared.CapaEntities.Response;

namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class EstadosController(SorteoestacionamientosContext db) : ControllerBase
    {

        private readonly SorteoestacionamientosContext _db = db;

        //Metodo para obtener la informacion mediante el Id
        [HttpGet("filterById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            Response<Catestado> oResponse = new();

            try
            {
                var item = await _db.Catestados.FindAsync(id);
                oResponse.Success = 1;
                oResponse.Data = item;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        //Metodo para agregar valor
        [HttpPost]
        public async Task<IActionResult> AddData(RequestViewModel_Estado model)
        {
            Response<object> oResponse = new();

            try
            {
                Catestado oEstado = new()
                {
                    IdEstado = model.IdEstado,
                    EdoNombre = model.EdoNombre
                };

                await _db.Catestados.AddAsync(oEstado);
                await _db.SaveChangesAsync();

                oResponse.Success = 1;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        //Metodo para editar valores
        [HttpPut]
        public async Task<IActionResult> EditData(RequestViewModel_Estado model)
        {
            Response<object> oResponse = new();

            try
            {
                Catestado? oEstado = await _db.Catestados.FindAsync(model.IdEstado);

                if (oEstado != null)
                {
                    oEstado.EdoNombre = model.EdoNombre;

                    _db.Entry(oEstado).State = EntityState.Modified;
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
