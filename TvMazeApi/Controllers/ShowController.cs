using Microsoft.AspNetCore.Mvc;
using CapaDatos.Models;
using CapaNegocio;
using TvMazeApi.FilterAuthorization;


namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        public readonly ShowBL _showBL ;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public ShowController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
            _showBL = new ShowBL(env);
        }

        [HttpGet(Name = "Show")]
        public IEnumerable<Show> Get()
        {
            
            return _showBL.ObtenerShows();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var objeto = _showBL.ObtenerShowByID(id);
            if (objeto != null)
            {
                return Ok(objeto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool flg=  _showBL.BorrarShowByID(id);
            if (flg)
            {
                return Ok(flg);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("LimpiarTvShow")]
        public bool LimpiarLista()
        {
            return _showBL.LimpiarLista();
        }


    }
}
