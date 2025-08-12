using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Primer_Api_Rest.Models;

namespace Primer_Api_Rest.Controllers
{
    [ApiController]
    [Route("api/home")]
public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Dictionary<int,Tarea> _listaTareas = new Dictionary<int, Tarea>();

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;

            this._listaTareas[1] = new Tarea(1, "Primer trabajo .NET", "Conociendo la plataforma .Net", 1, "Brian");
            this._listaTareas[2] = new Tarea(2, "Segundo trabajo .NET", "Experimentando en .Net", 4, "Brian");
            this._listaTareas[3] = new Tarea(3, "Tercer trabajo .NET", "Mira que lindo .Net", 2, "Brian");
            this._listaTareas[4] = new Tarea(4, "Cuarto trabajo .NET", "Experto en .Net", 10, "Brian");
            
           
        }

        [HttpGet]
        public ActionResult  GetAll()
        {
            _logger.LogInformation("Retorno lista de Tareas");
            return Ok(_listaTareas.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            _logger.LogInformation($"Retorno Tarea con el id : {id}");
            return Ok(_listaTareas[id]);
        }

        [HttpPost]
        public ActionResult CreateTarea([FromBody] Tarea Tarea)
        {
           
            this._listaTareas.Add(Tarea._Id,Tarea);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTarea(int id)
        {
            _logger.LogInformation("Eliminacion de Tarea");
            this._listaTareas.Remove(id);
            return Ok();
        }

        
    }
}
