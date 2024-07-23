using CapaDatos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace CapaDatos.ModelsExtented
{
    public class PeopleExtended
    {

       private readonly IHostingEnvironment  _env;

        public PeopleExtended(IHostingEnvironment env)
        {
            this._env = env;
        }

      
        public List<People> GetAll()
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "people.json");
            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                List<People> listPeople = JsonConvert.DeserializeObject<List<People>>(json) ?? new List<People>();
                return listPeople;
            }
            catch (Exception ex)
            {
                return new List<People>();

            }
        }

        public bool Add(People people)
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "people.json");
            try
            {
                List<People> listPeople = GetAll();
                listPeople.Add(people);
                var jsonGuardar = JsonConvert.SerializeObject(listPeople, Formatting.Indented);
                File.WriteAllText(_rutaArchivo, jsonGuardar);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(People people)
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "people.json");
            try
            {
                List<People> listPeople = GetAll();
                var indice = listPeople.FindIndex(x => x.id == people.id);
                listPeople[indice] = people;
                var jsonGuardar = JsonConvert.SerializeObject(listPeople, Formatting.Indented);
                File.WriteAllText(_rutaArchivo, jsonGuardar);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        public People GetById(int peopleId)
        {

                List<People> listPeople = GetAll();
                 return listPeople.SingleOrDefault(person => person.id == peopleId);


        }
        public bool DeleteById(int peopleid)
        {
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "people.json");
            try
            {
                List<People> listPeople = GetAll();
                var indice = listPeople.FindIndex(x => x.id == peopleid);
                listPeople.RemoveAt(indice);
                var jsonGuardar = JsonConvert.SerializeObject(listPeople, Formatting.Indented);
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
            string _rutaArchivo = Path.Combine(_env.ContentRootPath, "App_Data", "people.json");
            try
            {
                List<People> listPeople = GetAll();
                listPeople.Clear();
                var jsonGuardar = JsonConvert.SerializeObject(listPeople, Formatting.Indented);
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
