using CapaDatos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class TvMazeShowService
    {
        private readonly HttpClient _httpClient;

        private readonly string url = "http://api.tvmaze.com/"; //"//ConfigurationManager.AppSettings["UrlApiTvMaze"];
        public TvMazeShowService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(url) };
        }

        public async Task<List<Show>> ObtenerTvShowsAsync()
        { 
            try
            {
                var response = await _httpClient.GetAsync("shows");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<List<Show>>(content);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
