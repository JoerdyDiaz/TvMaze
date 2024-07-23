using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tvmaze.Controllers
{
    public class PeopleController : ApiController
    {

        private PeopleBL _tvmazeBl;
        public PeopleController()
        {
            _tvmazeBl = new PeopleBL();
        }

        public IHttpActionResult Get()
        {
            return Ok(_tvmazeBl.ObtenerPeople());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_tvmazeBl.ObtenerPeopleById(id));
        }
    }
}
