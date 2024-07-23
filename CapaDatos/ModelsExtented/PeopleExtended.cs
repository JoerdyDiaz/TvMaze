using CapaDatos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CapaDatos.ModelsExtented
{
    public class PeopleExtended
    {
        private readonly string _rutaArchivo = HostingEnvironment.MapPath("~/App_Data/people.json");

        public List<People> GetAll()
        {
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
            try
            {
                List<People> listPeople = GetAll();
                return listPeople.Where(x=> x.id.Equals(peopleId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public bool DeleteById(int peopleid)
        {
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
