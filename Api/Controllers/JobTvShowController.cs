using CapaDatos.Models;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.FilterAuthorization;
using CapaServicios;

namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyRequired]
    public class JobTvShowController : ControllerBase
    {

        public readonly ShowBL _showBL;
        private readonly ITvMazeShowService _dataService;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public JobTvShowController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ITvMazeShowService _iservice)
        {
            _dataService = _iservice;
            _showBL = new ShowBL(env);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Show> ListShow =   await _dataService.ObtenerTvShowsAsync();
            if (ListShow != null && ListShow.Count > 0)
            {
                _showBL.LimpiarLista();
                foreach (var show in ListShow)
                {
                    _showBL.Agregar(show);
                }
            }

            return Ok("Job ejecutado correctamente.");
        }
    }
}
