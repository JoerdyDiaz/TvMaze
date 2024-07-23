using CapaDatos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Hosting;

namespace CapaDatos.ModelsExtented
{
    public class ShowExtended
    {

        private readonly IHostingEnvironment _env;

        public ShowExtended(IHostingEnvironment env)
        {
            this._env = env;
        }

        public List<Show> GetAll()
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "show.json");
            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                List<Show> show = JsonConvert.DeserializeObject<List<Show>>(json) ?? new List<Show>();
                return show;
            }
            catch (Exception ex)
            {
                return new List<Show>();

            }
        }
        public bool Add(Show show)
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "show.json");
            try
            {
                List<Show> shows = GetAll();
                shows.Add(show);
                var jsonGuardar = JsonConvert.SerializeObject(shows, Formatting.Indented);
                File.WriteAllText(_rutaArchivo, jsonGuardar);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Show show)
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "show.json");
            try
            {

                List<Show> shows = GetAll();
                var indice = shows.FindIndex(x => x.id == show.id);
                shows[indice] = show;
                var jsonGuardar = JsonConvert.SerializeObject(shows, Formatting.Indented);
                File.WriteAllText(_rutaArchivo, jsonGuardar);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public Show GetById(int showID)
        {
            try
            {
                List<Show> show = GetAll();
                return show.Where(x=> x.id.Equals(showID)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;

            }
        }


        public bool DeleteById(int showid)
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "show.json");
            try
            {
                List<Show> shows = GetAll();
                var indice = shows.FindIndex(x => x.id == showid);
                shows.RemoveAt(indice);
                var jsonGuardar = JsonConvert.SerializeObject(shows, Formatting.Indented);
                File.WriteAllText(_rutaArchivo, jsonGuardar);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool DeleteAll()
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "show.json");
            try
            {
                List<Show> shows = GetAll();
                shows.Clear();
                var jsonGuardar = JsonConvert.SerializeObject(shows, Formatting.Indented);
                File.WriteAllText(_rutaArchivo, jsonGuardar);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
