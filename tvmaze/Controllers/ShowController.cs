using CapaDatos.Models;
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
    public class ShowController : ApiController
    {

        private ShowBL _tvmazeBl;
        public ShowController()
        {
            _tvmazeBl = new ShowBL();
        }

        public IEnumerable<Show> Get()
        {
            return _tvmazeBl.ObtenerShows().ToArray();
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_tvmazeBl.ObtenerShowByID(id));
        }

        public IHttpActionResult Delete(int id)
        {
            return Ok(_tvmazeBl.BorrarShowByID(id));
        }
    }
}
