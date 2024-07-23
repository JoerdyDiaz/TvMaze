using CapaDatos.Models;
//using CapaDatos.AdoModelEF;
using CapaDatos.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CapaDatos.ModelsExtented;
using System.Configuration;

namespace CapaServicios
{
    public class TvMazeShowService
    {
        private readonly HttpClient _httpClient;

        private readonly string url = ConfigurationManager.AppSettings["UrlApiTvMaze"];
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
                return JsonConvert.DeserializeObject<List<Show>>(content);
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }
    }
}
