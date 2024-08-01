using Microsoft.AspNetCore.Mvc;
using CapaDatos.Models;
using CapaNegocio;
using Api.FilterAuthorization;


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
            _showBL = new ShowBL(env);
        }

        [HttpGet(Name = "Show")]
        public IActionResult Get()
        {
            
            return Ok(_showBL.ObtenerShows());
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


        [HttpPut]
        public IActionResult Update(Show show)
        {
            var objeto = _showBL.ObtenerShowByID(show.id);
            if (objeto == null)
            {
                return NotFound();
               
            }
            else
            {
                return Ok(_showBL.Modificar(show));
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
