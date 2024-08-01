using CapaDatos.Models;
using CapaDatos.ModelsExtented;
using Microsoft.AspNetCore.Hosting;
using CapaServicios;

namespace CapaNegocio
{
    public class ShowBL
    {

        private IHostingEnvironment _env;
        public ShowBL(IHostingEnvironment env)
        {
            _env = env;

        }
 
        public List<Show> ObtenerShows()
        {
            List<Show> listShow = new List<Show>();
            try
            {
                ShowExtended obj = new ShowExtended(_env);
                return listShow = obj.GetAll();
            }
            catch (Exception ex)
            {
                return listShow;
            }

        }

        public bool LimpiarLista()
        {
            ShowExtended obj = new ShowExtended(_env);
            return obj.DeleteAll();
        }

        public bool Agregar(Show item)
        {
            ShowExtended obj = new ShowExtended(_env);
            return obj.Add(item);
        }

        public bool Modificar(Show item)
        {
            ShowExtended obj = new ShowExtended(_env);
            return obj.Update(item);
        }

        public Show ObtenerShowByID(int showID)
        {
            ShowExtended obj = new ShowExtended(_env);
            return obj.GetById(showID);
        }

        public bool BorrarShowByID(int showID)
        {
            ShowExtended obj = new ShowExtended(_env);
            return obj.DeleteById(showID);
        }

    }
}
