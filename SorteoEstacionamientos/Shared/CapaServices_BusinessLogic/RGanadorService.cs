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
    public class RGanadorService(HttpClient httpClient) : IGenericService<RequestDTO_Ganador>
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };
        const string url = "/api/Ganadores";

        public async Task<Response<List<RequestDTO_Ganador>>?> GetAllDataByStatusAsync(short filterByStatus)
        {
            var response = await _httpClient.GetAsync($"{url}/filterByStatus/{filterByStatus}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Response<List<RequestDTO_Ganador>>>(content, options: _options);
            return result;
        }

        public async Task<Response<RequestDTO_Ganador>?> GetDataByIdAsync(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response<RequestDTO_Ganador>>($"{url}/filterById/{id}", options: _options);
            return result;
        }

        public async Task<Response<RequestDTO_Ganador>?> GetDataByWinParticipante(int? idwinParticipante)
        {
            var result = await _httpClient.GetFromJsonAsync<Response<RequestDTO_Ganador>>($"{url}/filterById/{idwinParticipante}", options: _options);
            return result;
        }

        public async Task<HttpResponseMessage> AddDataAsync(RequestDTO_Ganador oGanador)
        {
            // var json = JsonSerializer.Serialize(oGanador);
            // var content = new StringContent(json, Encoding.UTF8, "application/json");
            // var response = await _httpClient.PostAsync(url, content);
            var response = await _httpClient.PostAsJsonAsync(url, oGanador, options: _options);
            return response;
        }

        public async Task<HttpResponseMessage> EditDataAsync(RequestDTO_Ganador oGanador)
        {
            // var json = JsonSerializer.Serialize(oGanador);
            // var content = new StringContent(json, Encoding.UTF8, "application/json");
            // var response = await _httpClient.PutAsync(url, content);
            var response = await _httpClient.PutAsJsonAsync(url, oGanador, options: _options);
            return response;
        }

        public async Task<HttpResponseMessage> EnableDisableDataByIdAsync(int id, short isActivate)
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
