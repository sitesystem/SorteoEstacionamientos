using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamiento.Server.CapaDataAccess.DBContext;

using SorteoEstacionamiento.Shared.CapaEntities.Request;
using SorteoEstacionamiento.Shared.CapaEntities.Response;


namespace SorteoEstacionamiento.Server.CapaDataAccess.Controllers
{
    public class TipoParticipantesController(SorteoestacionamientosContext db) : ControllerBase
    {
        private readonly SorteoestacionamientosContext _db = db;

        //Metodo para obtener la informacion mediante el id
        [HttpGet("filterById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            Response<Cattipoparticipante> oResponse = new();

            try
            {
                var item = await _db.Cattipoparticipantes.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_TipoParticipante model)
        {
            Response<object> oResponse = new();

            try
            {
                Cattipoparticipante oTipoParticipante = new()
                {
                    IdTipoParticipante = model.IdTipoParticipante,
                    TipoParticipante = model.TipoParticipante
                };

                await _db.Cattipoparticipantes.AddAsync(oTipoParticipante);
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
        public async Task<IActionResult> EditData(RequestViewModel_TipoParticipante model)
        {
            Response<object> oResponse = new();

            try
            {
                Cattipoparticipante? oTipoParticipante = await _db.Cattipoparticipantes.FindAsync(model.IdTipoParticipante);

                if (oTipoParticipante != null)
                {
                    oTipoParticipante.TipoParticipante = model.TipoParticipante;

                    _db.Entry(oTipoParticipante).State = EntityState.Modified;
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
