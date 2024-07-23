using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Models;
using CapaDatos.ModelsExtented;
using Microsoft.AspNetCore.Hosting;

namespace CapaNegocio
{
    public class PeopleBL
    {

        private  IHostingEnvironment _env;

        public PeopleBL(IHostingEnvironment env)
        {
            _env = env;
        }


        public List<People> ObtenerPeople()
        {
            List<People> listShow = new List<People>();
            try
            {
                PeopleExtended obj = new PeopleExtended(_env);
                return listShow = obj.GetAll();
            }
            catch (Exception ex)
            {
                return listShow;
            }

        }

        public bool LimpiarLista()
        {
            PeopleExtended obj = new PeopleExtended(_env);
            return obj.DeleteAll();
        }

        public bool Agregar(People item)
        {
            PeopleExtended obj = new PeopleExtended(_env);
            return obj.Add(item);
        }

        public People ObtenerPeopleById(int peopleId)
        {
            PeopleExtended obj = new PeopleExtended(_env);
            return obj.GetById(peopleId);
        }

        public bool BorrarPeopleByID(int peopleid)
        {
            PeopleExtended obj = new PeopleExtended(_env);
            return obj.DeleteById(peopleid);
        }

    }
}
