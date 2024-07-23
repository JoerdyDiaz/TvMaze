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
    public class JobTvShowController : ApiController
    {
        private readonly ShowBL _tvMazeShowBL;
        public JobTvShowController()
        {
            _tvMazeShowBL = new ShowBL();
        }

        [ApiKeyAuth]
        public async Task<IHttpActionResult> EjecutarJob()
        {
            await _tvMazeShowBL.ActualizarTvShowsAsync();
            return Ok("Job ejecutado correctamente.");
        }
    }
}