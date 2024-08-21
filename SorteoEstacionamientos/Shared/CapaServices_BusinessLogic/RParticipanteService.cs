using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Shared.CapaServices_BusinessLogic
{
	public class RParticipanteService(HttpClient httpClient) : IGenericService<RequestDTO_Participante>
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };
		const string url = "/api/Participantes";

		public async Task<Response<List<RequestDTO_Participante>>?> GetAllDataByStatusAsync(short filterByStatus)
		{
			var response = await _httpClient.GetAsync($"{url}/filterByStatus/{filterByStatus}");
			var content = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<Response<List<RequestDTO_Participante>>>(content, options: _options);
			return result;
		}

		public async Task<Response<RequestDTO_Participante>?> GetDataByIdAsync(int? id)
		{
			var result = await _httpClient.GetFromJsonAsync<Response<RequestDTO_Participante>>($"{url}/filterById/{id}", options: _options);
			return result;
		}

		public async Task<Response<RequestDTO_Participante>?> ValidateByEmailCURP(string correo, string curp)
		{
			var result = await _httpClient.GetFromJsonAsync<Response<RequestDTO_Participante>>($"{url}/filterByEmailCURP/{correo}/{curp}", options: _options);
			return result;
		}

		public async Task<HttpResponseMessage> AddDataAsync(RequestDTO_Participante oParticipante)
		{
			// var json = JsonSerializer.Serialize(oUsuario);
			// var content = new StringContent(json, Encoding.UTF8, "application/json");
			// var response = await _httpClient.PostAsync(url, content);
			var response = await _httpClient.PostAsJsonAsync(url, oParticipante, options: _options);
			return response;
		}

		public async Task<HttpResponseMessage> EditDataAsync(RequestDTO_Participante oParticipante)
		{
			// var json = JsonSerializer.Serialize(oUsuario);
			// var content = new StringContent(json, Encoding.UTF8, "application/json");
			// var response = await _httpClient.PutAsync(url, content);
			var response = await _httpClient.PutAsJsonAsync(url, oParticipante, options: _options);
			return response;
		}

        public async Task<HttpResponseMessage> ResetPassword(string correoInstitucional, string curp)
        {
            var response = await _httpClient.PutAsJsonAsync($"{url}/resetPassword/{correoInstitucional}/{curp}",
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true
                 });

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
