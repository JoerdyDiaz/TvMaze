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
    public class PeopleBL
    {
        //private readonly TvMazeContext _context ;
        private readonly TvMazePeopleService _tvMazeService;
        private readonly Show _show;
        public PeopleBL()
        {
            //_show = new Show();
            _tvMazeService = new TvMazePeopleService();
        }

        public async Task ActualizarPeopleAsync()
        {

            try
            {
                List<People> ListPeople = await _tvMazeService.ObtenerPeopleAsync();
                if (ListPeople != null && ListPeople.Count > 0)
                {
                    LimpiarLista();
                    foreach (var people in ListPeople)
                    {
                        Agregar(people);
                    }
                }
            }
            catch (Exception ex)
            {

            }            
        }

        public List<People> ObtenerPeople()
        {      
            List<People> listShow = new List<People>();
            try
            {
                PeopleExtended obj = new PeopleExtended();
               return listShow = obj.GetAll();
            }
            catch (Exception ex)
            {
                return listShow;
            }
        
        }

        public bool LimpiarLista()
        {
            PeopleExtended obj = new PeopleExtended();
            return obj.DeleteAll();
        }

        public bool Agregar(People item)
        {
            PeopleExtended obj = new PeopleExtended();
            return obj.Add(item);
        }

        public People ObtenerPeopleById(int peopleId)
        {
            PeopleExtended obj = new PeopleExtended();
            return obj.GetById(peopleId);
        }

        public bool BorrarPeopleByID(int peopleid)
        {
            PeopleExtended obj = new PeopleExtended();
            return obj.DeleteById(peopleid);
        }
    }
}
