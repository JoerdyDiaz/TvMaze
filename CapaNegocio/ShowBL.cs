//using CapaDatos.AdoModelEF;
using CapaDatos.ModelsExtented;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaDatos.Models;

namespace CapaNegocio
{
    public class ShowBL
    {
        //private readonly TvMazeContext _context ;
        private readonly TvMazeShowService _tvMazeService;
        private Show _show;
        public ShowBL()
        {
            _show = new Show();
            _tvMazeService = new TvMazeShowService();
        }

        public async Task ActualizarTvShowsAsync()
        {

            try
            {
                List<Show> tvShows = await _tvMazeService.ObtenerTvShowsAsync();
                if (tvShows != null && tvShows.Count > 0)
                {
                    LimpiarLista();
                    foreach (var show in tvShows)
                    {
                        Agregar(show);
                    }
                }
            }
            catch (Exception ex)
            {

            }            
        }

        public List<Show> ObtenerShows()
        {      
            List<Show> listShow = new List<Show>();
            try
            {
                ShowExtended obj = new ShowExtended();
               return listShow = obj.GetAll();
            }
            catch (Exception ex)
            {
                return listShow;
            }
        
        }

        public bool LimpiarLista()
        {
            ShowExtended obj = new ShowExtended();
            return obj.DeleteAll();
        }

        public bool Agregar(Show item)
        {
            ShowExtended obj = new ShowExtended();
            return obj.Add(item);
        }

        public Show ObtenerShowByID(int showID)
        {
            ShowExtended obj = new ShowExtended();
            return obj.GetById(showID);
        }

        public bool BorrarShowByID(int showID)
        {
            ShowExtended obj = new ShowExtended();
            return obj.DeleteById(showID);
        }
    }
}
