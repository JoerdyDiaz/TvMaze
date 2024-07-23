using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace tvmaze.Controllers
{
    public class JobPeopleController : ApiController
    {
        private readonly PeopleBL _tvMazePeopleBL;

        public JobPeopleController()
        {
            _tvMazePeopleBL = new PeopleBL();
        }

        [ApiKeyAuth]
        public async Task<IHttpActionResult> EjecutarJob()
        {
            await _tvMazePeopleBL.ActualizarPeopleAsync();
            return Ok("Job ejecutado correctamente.");
        }
    }
}