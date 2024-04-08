﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.MóduloCatálogos
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CarrerasController(DBSorteoParkingContext db, ILogger<CarrerasController> logger) : ControllerBase
    {
        private readonly DBSorteoParkingContext _db = db;
        private readonly ILogger<CarrerasController> _logger = logger;

        [HttpGet("filterByStatus/{filterByStatus}")]
        public async Task<IActionResult> GetAllDataByStatus(short filterByStatus)
        {
            Response<List<McCatCarrera>> oResponse = new();

            try
            {
                var list = new List<McCatCarrera>();

                if (filterByStatus == 1)
                    list = await _db.McCatCarreras.Where(c => c.CarrStatus == filterByStatus).ToListAsync();
                else
                    list = await _db.McCatCarreras.ToListAsync();

                if (list == null)
                {
                    _logger.LogWarning("No existen registros de Carreras.");
                    return BadRequest(oResponse);
                }

                _logger.LogInformation("Consulta de todos los registros de Carreras.");

                oResponse.Success = 1;
                oResponse.Data = list;
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                _logger.LogError(ex, "ERROR");
            }

            return Ok(oResponse);
        }

        [HttpGet("filterById/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            Response<McCatCarrera> oResponse = new();

            try
            {
                var item = await _db.McCatCarreras.FindAsync(id);
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
        public async Task<IActionResult> AddData(RequestViewModel_Carrera model)
        {
            Response<object> oResponse = new();

            try
            {
                McCatCarrera oCarrera = new()
                {
                    IdCarrera = model.IdCarrera,
                    CarrClave = model.CarrClave,
                    CarrNombre = model.CarrNombre,
                    CarrStatus = 1
                };

                await _db.McCatCarreras.AddAsync(oCarrera);
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
        public async Task<IActionResult> EditData(RequestViewModel_Carrera model)
        {
            Response<object> oRespuesta = new();

            try
            {
                McCatCarrera? oCarrera = await _db.McCatCarreras.FindAsync(model.IdCarrera);

                if (oCarrera != null)
                {
                    oCarrera.CarrClave = model.CarrClave;
                    oCarrera.CarrNombre = model.CarrNombre;
                    oCarrera.CarrStatus = model.CarrStatus;

                    _db.Entry(oCarrera).State = EntityState.Modified;
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
                McCatCarrera? oCarrera = await _db.McCatCarreras.FindAsync(id);

                //db.Remove(oPersona);
                if (oCarrera != null)
                {
                    oCarrera.CarrStatus = isActivate;
                    _db.Entry(oCarrera).State = EntityState.Modified;
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
