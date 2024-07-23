using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace tvmaze.Controllers
{
    public class HomeController : Controller
    {
       // public async Task<ActionResult> Index()
       public ActionResult Index()
       {
            ViewBag.Title = "Home Page";

            //JobController job = new JobController();
            //await job.EjecutarJob();
            // job.Agregar();
            //job.modificar();           
            return View();
       }
    }
}
