using Newtonsoft.Json;
using CapaDatos.Models;
using CapaDatos.ModelsExtented;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace CapaServicios
{
    public class TvMazePeopleService : ITvMazePeopleService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiExternaSettings _apiSettings;
        public TvMazePeopleService(HttpClient httpClient, IOptions<ApiExternaSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task<List<People>> ObtenerPeopleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}{_apiSettings.EndpointPeople}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<People>>(content);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
