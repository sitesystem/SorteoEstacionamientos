using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloSorteo
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanadoresController(DBSorteoParkingContext db, IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<MsTbGanadore>> oResponse = new();

            try
            {
                var list = new List<MsTbGanadore>();

                if (filterByStatus == 1)
                    list = await _db.MsTbGanadores.Where(g => g.IdGanador == filterByStatus).ToListAsync();
                else
                    list = await _db.MsTbGanadores.ToListAsync();

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
            Response<MsTbGanadore> oResponse = new();

            try
            {
                var item = await _db.MsTbGanadores.FindAsync(id);
                oResponse.Success = 1;
                oResponse.Data = item;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);   
        }

        [HttpGet("filterByWinParticipante/{winParticipante}")]
        public async Task<IActionResult> GetDataByWinParticipante(int winParticipante)
        {
            Response<List<MsTbGanadore>> oResponse = new();

            try
            {
                var list = new List<MsTbGanadore>();

                if (winParticipante == 1)
                    list = await _db.MsTbGanadores.Where(wp => wp.IdGanador == winParticipante).ToListAsync();
                else
                    list = await _db.MsTbGanadores.ToListAsync();

                oResponse.Success = 1;
                oResponse.Data = list;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse );
        }

        [HttpPost]
        public async Task<IActionResult> AddData(RequestDTO_Ganador model)
        {
            Response<object> oResponse = new();
            CreatedAtActionResult oCreatedAtActionResult;

            try
            {
                MsTbGanadore oGanador = new()
                {
                    IdGanador = model.IdGanador,
                    WinIdParticipante = model.WinIdParticipante,
                    WinFechaHoraSorteo = model.WinFechaHoraSorteo
                };

                await _db.MsTbGanadores.AddAsync(oGanador);
                await _db.SaveChangesAsync();

                oResponse.Success = 1;

                //oCreatedAtActionResult = CreatedAtAction(nameof(AddData), new { id = oUsuario.IdUsuario }, oUsuario);
                //oResponse.Message = oUsuario.IdUsuario.ToString(); // PK ID Único del Usuario Creado o dado de Alta
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);   
        }

        [HttpPut]
        public async Task<IActionResult> EditData(RequestDTO_Ganador model)
        {
            Response<object> oResponse = new();

            try
            {
                MsTbGanadore? oGanador = await _db.MsTbGanadores.FindAsync(model.IdGanador);

                if(oGanador != null)
                {
                    oGanador.IdGanador = model.IdGanador;
                    oGanador.WinIdParticipante = model.WinIdParticipante;
                    oGanador.WinFechaHoraSorteo = model.WinFechaHoraSorteo;

                    _db.Entry(oGanador).State = EntityState.Modified;
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
        public async Task<IActionResult> EnableDisableDataById(int id, short isActivate)
        {
            Response<object> oResponse = new();

            try
            {
                MsTbGanadore? oGanador = await _db.MsTbGanadores.FindAsync(id);

                if (oGanador != null)
                {
                    oGanador.IdGanador = isActivate;
                    _db.Entry(oGanador).State = EntityState.Modified;
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
