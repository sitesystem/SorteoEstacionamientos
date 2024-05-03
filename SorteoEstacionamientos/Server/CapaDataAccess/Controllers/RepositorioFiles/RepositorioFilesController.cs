using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net.Http.Headers;

using SorteoEstacionamientos.Shared.CapaEntities.Response;

//namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.RepositorioFiles
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RepositorioFilesController(IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment) : ControllerBase
//    {
//        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
//        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

//        [HttpPost("[action]/{folder}/{id}/{filename}/{guid}")]
//        public async Task<IActionResult> UploadSingFile(string folder, int id, string fileName, Guid guid, IFormFile file)
//        {

//        }
//    }
//}
