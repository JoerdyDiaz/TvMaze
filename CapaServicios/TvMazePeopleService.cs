using Newtonsoft.Json;
using CapaDatos.Models;
using CapaDatos.ModelsExtented;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class TvMazePeopleService
    {
        private readonly HttpClient _httpClient;

        private readonly string url = "http://api.tvmaze.com/"; // ConfigurationManager.AppSettings["UrlApiTvMaze"];
        public TvMazePeopleService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(url) };
        }

        public async Task<List<People>> ObtenerPeopleAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("people");
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
