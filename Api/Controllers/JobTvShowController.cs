using CapaDatos.Models;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.FilterAuthorization;

namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyRequired]
    public class JobTvShowController : ControllerBase
    {

        public readonly ShowBL _showBL;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public JobTvShowController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
            _showBL = new ShowBL(env);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _showBL.ActualizarTvShowsAsync();
            return Ok("Job ejecutado correctamente.");
        }
    }
}
