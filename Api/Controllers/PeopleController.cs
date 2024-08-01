using CapaDatos.Models;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        public readonly PeopleBL peopleBL;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public PeopleController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            peopleBL = new PeopleBL(env);
        }

        [HttpGet(Name = "People")]
        public IActionResult Get()
        {
            return Ok(peopleBL.ObtenerPeople());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var objeto = peopleBL.ObtenerPeopleById(id);
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
        public IActionResult Update(People people)
        {
            var objeto = peopleBL.ObtenerPeopleById(people.id);
            if (objeto == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(peopleBL.Modificar(people));
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var objeto = peopleBL.BorrarPeopleByID(id);
            if (objeto)
            {
                return Ok(objeto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("LimpiarPeople")]
        public bool LimpiarLista()
        {
            return peopleBL.LimpiarLista();
        }
    }
}
