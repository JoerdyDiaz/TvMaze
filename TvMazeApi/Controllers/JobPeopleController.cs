using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.FilterAuthorization;

namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyRequired]
    public class JobPeopleController : ControllerBase
    {
        public readonly PeopleBL _peopleBL;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public JobPeopleController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
            _peopleBL = new PeopleBL(env);
        }

        [HttpPut]
        public async Task<IActionResult> Get()
        {
            await _peopleBL.ActualizarPeoplesync();
            return Ok("Job ejecutado correctamente.");
        }
    }
}
