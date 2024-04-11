using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaServices_BusinessLogic
{
    public class RPeriodoRegistroService(HttpClient httpClient) : IGenericService<RequestDTO_PeriodoRegistro>
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };
        const string url = "/api/PeriodoRegistros";

        public async Task<Response<List<RequestDTO_PeriodoRegistro>>?> GetAllDataByStatusAsync(bool filterByStatus)
        {
            var response = await _httpClient.GetAsync($"{url}/filterByStatus/{filterByStatus}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Response<List<RequestDTO_PeriodoRegistro>>>(content, options: _options);
            return result;
        }

        public async Task<Response<RequestDTO_PeriodoRegistro>?> GetDataByIdAsync(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response<RequestDTO_PeriodoRegistro>>($"{url}/filterById/{id}", options: _options);
            return result;
        }

        public async Task<HttpResponseMessage> AddDataAsync(RequestDTO_PeriodoRegistro oPeriodoRegistro)
        {
            //var json = JsonSerializer.Serialize(oPeriodoRegristro);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PostAsync(url, content);
            var response = await _httpClient.PostAsJsonAsync(url, oPeriodoRegistro, options: _options);
            return response;
        }

        public async Task<HttpResponseMessage> EditDataAsync(RequestDTO_PeriodoRegistro oPeriodoRegistro)
        {
            //var json = JsonSerializer.Serialize(oPeriodoRegistro);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PutAsync(url, content);
            var response = await _httpClient.PutAsJsonAsync(url, oPeriodoRegistro, options: _options);
            return response;
        }

        public async Task<HttpResponseMessage> EnableDisableDataByIdAsync(int id, bool isActivate)
        {
            var response = await _httpClient.PutAsJsonAsync($"{url}/editByIdStatus/{id}/{isActivate}",
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            return response;
        }
    }
}
