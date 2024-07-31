using CapaDatos.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class TvMazeShowService: ITvMazeShowService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiExternaSettings _apiSettings;

        public TvMazeShowService(HttpClient httpClient, IOptions<ApiExternaSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task<List<Show>> ObtenerTvShowsAsync()
        { 
            try
            {
                var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}{_apiSettings.EndpointShow}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Show>>(content);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
