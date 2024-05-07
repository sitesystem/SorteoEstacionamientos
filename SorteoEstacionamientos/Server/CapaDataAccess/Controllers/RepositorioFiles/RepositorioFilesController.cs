using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Http.Headers;

using SorteoEstacionamientos.Shared.CapaEntities.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Hosting;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.RepositorioFiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositorioFilesController(IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpPost("[action]/{folder}/{id}/{filename}/{guid}")]
        public async Task<IActionResult> UploadSingFile(string folder, int id, string fileName, Guid guid, IFormFile file) //Guid = tokken
        {
            Response<object> oResponse = new();
            try
            {
                if (file.Length > 0 && file != null)
                {
                    folder = Path.Combine(_webHostEnvironment.ContentRootPath, $"wwwroot/repositorio/{folder}/{id}");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    fileName = $"{id}_{Path.GetFileNameWithoutExtension(fileName)}_{guid}{Path.GetExtension(file.FileName).ToLower()}";

                    string dirPath = Path.Combine(folder, fileName);

                    if (!System.IO.File.Exists(dirPath))
                    {
                        using FileStream oFileStream = new(dirPath, FileMode.Create, FileAccess.Write);
                        await file.OpenReadStream().CopyToAsync(oFileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
                oResponse.Message = ex.Message; 
            }

            return Ok(oResponse);
        }

        [HttpPost("[action]/{folder}/{id}/{fileName}/{guid}")]
        public async Task<IActionResult> UploadMultipleFiles(string folder, int id, string fileName, Guid guid, IList<IFormFile> files)
        {
            Response<object> oResponse = new();
            try
            {
                if (files.Count < 1 || files.IsNullOrEmpty())
                    return BadRequest(oResponse);

                foreach (var file in files)
                {
                    folder = Path.Combine(_webHostEnvironment.ContentRootPath, $"wwwroot/repositorio/{folder}/{id}");

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    fileName = $"{id}_{fileName}_{guid}{Path.GetExtension(file.FileName).ToLower()}";
                    long size = file.Length;

                    string dirPath = Path.Combine(folder, fileName);

                    if (!System.IO.File.Exists(dirPath))
                    {
                        using FileStream oFileStream = new(dirPath, FileMode.Create, FileAccess.Write);
                        await file.OpenReadStream().CopyToAsync(oFileStream);
                    }
                }
                oResponse.Success = 1;
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File Failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost("[action]")]
        public async Task RemoveFile(IList<IFormFile> UploadFiles)
        {
            try
            {
                var fileName = _hostEnvironment.ContentRootPath + $"/{UploadFiles[0].FileName}";

                if(System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }

    }
}
