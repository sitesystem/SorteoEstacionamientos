﻿using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SorteoEstacionamientos.Shared.CapaServices_BusinessLogic
{
    public class RLinkService(HttpClient httpClient) : IGenericService<RequestViewModel_Link>
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };
        const string url = "/api/Links";

        public async Task<Response<List<RequestViewModel_Link>>?> GetAllDataByStatusAsync(short filterByStatus)
        {
            var response = await _httpClient.GetAsync($"{url}/filterByStatus/{filterByStatus}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Response<List<RequestViewModel_Link>>>(content, options: _options);
            return result;
        }

        public async Task<Response<RequestViewModel_Link>?> GetDataByIdAsync(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response<RequestViewModel_Link>>($"{url}/filterById/{id}", options: _options);
            return result;
        }

        public async Task<Response<RequestViewModel_Link>?> GetDataByNameAsync(string name)
        {
            var result = await _httpClient.GetFromJsonAsync<Response<RequestViewModel_Link>>($"{url}/filterByName/{name}", options: _options);
            return result;
        }

        public async Task<HttpResponseMessage> AddDataAsync(RequestViewModel_Link oLink)
        {
            //var json = JsonSerializer.Serialize(oLink);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PostAsync(url, content);
            var response = await _httpClient.PostAsJsonAsync(url, oLink, options: _options);
            return response;
        }

        public async Task<HttpResponseMessage> EditDataAsync(RequestViewModel_Link oLink)
        {
            //var json = JsonSerializer.Serialize(oLink);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PutAsync(url, content);
            var response = await _httpClient.PutAsJsonAsync(url, oLink, options: _options);
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
