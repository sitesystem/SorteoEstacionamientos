using Microsoft.AspNetCore.Components.Forms;
using SorteoEstacionamientos.Shared.CapaEntities.Response;
using SorteoEstacionamientos.Shared.Constantes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SorteoEstacionamientos.Shared.CapaServices_BusinessLogic
{
    public class RArchivosService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive =  true};
        const string url = "/api/archivos";

        public async Task<string?> SubirDocumento(TipoDocumento documento, IBrowserFile file)
        {
            string? result = null;
            using (MultipartFormDataContent content = new MultipartFormDataContent())
            {
                using (StreamContent fileContent = new StreamContent(file.OpenReadStream()))
                {
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                    content.Add(fileContent, name: "\"file\"", file.Name);

                    //SUBIR
                    HttpResponseMessage httpResponse = await _httpClient.PostAsync($"{url}/subir/{(int)documento}", content);

                    string json = await httpResponse.Content.ReadAsStringAsync();
                    var response = JsonSerializer.Deserialize<Response<string?>>(json, options: _options);

                    if (response is not null)
                    {
                        result = response.Data;
                    }
                }       
            }
            return result;
        }

        public async Task<Response<string>?> NewFile(string extension, string action)
        {
            var response = await _httpClient.GetAsync($"{url}/{extension}/{action}");

            var content = await response.Content.ReadAsStringAsync() ;
            var result = JsonSerializer.Deserialize<Response<string>>(content, options: _options);
            return result;
        }

        //public async Task<Response<List<WebUtils.Link>>?> NewFileFromSelection<T>(string extension, string action, List<T> selected)
        //{

        //}
    }
}
