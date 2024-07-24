﻿using Microsoft.AspNetCore.Mvc;
using CapaDatos.Models;
using CapaNegocio;
using TvMazeApi.FilterAuthorization;


namespace TvMazeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiKeyRequired]
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
        public Show Get(int id)
        {
            return  _showBL.ObtenerShowByID(id);
        }

        [HttpGet("Delete/{id}")]
        public bool Delete(int id)
        {
            return _showBL.BorrarShowByID(id);
        }
    }
}
