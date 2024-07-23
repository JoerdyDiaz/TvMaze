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
            _env = env;
            peopleBL = new PeopleBL(env);
        }

        [HttpGet(Name = "People")]
        public IEnumerable<People> Get()
        {

            return peopleBL.ObtenerPeople();
        }

        [HttpGet("{id}")]
        public People Get(int id)
        {
            return peopleBL.ObtenerPeopleById(id);
        }
    }
}
