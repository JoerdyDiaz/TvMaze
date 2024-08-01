using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.FilterAuthorization;
using CapaServicios;
using CapaDatos.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyRequired]
    public class JobPeopleController : ControllerBase
    {
        public readonly PeopleBL _peopleBL;
        private readonly ITvMazePeopleService _dataService;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public JobPeopleController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ITvMazePeopleService _iservice)
        {
            _dataService = _iservice;
            _peopleBL = new PeopleBL(env);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<People> ListPeople =   await _dataService.ObtenerPeopleAsync();
            if (ListPeople != null && ListPeople.Count > 0)
            {            
                foreach (var people in ListPeople)
                {
                    var obj = _peopleBL.ObtenerPeopleById(people.id);
                    if (obj == null)
                        _peopleBL.Agregar(people);
                    else
                        _peopleBL.Modificar(people);
                }
            }

            return Ok("Job ejecutado correctamente.");
        }
    }
}
