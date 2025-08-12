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
        private IList<Tarea> _listaTareas;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;

            this._listaTareas =
            [
                new Tarea(1, "Primer trabajo .NET", "Conociendo la plataforma .Net", 1, "Brian"),
                new Tarea(2, "Segundo trabajo .NET", "Experimentando en .Net", 4, "Brian"),
                new Tarea(3, "Tercer trabajo .NET", "Mira que lindo .Net", 2, "Brian"),
                new Tarea(4, "Cuarto trabajo .NET", "Experto en .Net", 10, "Brian"),
            ];
           
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
            return Ok(_listaTareas[id - 1]);
        }

        [HttpPost]
        public ActionResult CreateTarea([FromBody] Tarea Tarea)
        {
           
            this._listaTareas.Add(Tarea);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTarea(int id)
        {
            _logger.LogInformation("Eliminacion de Tarea");
            this._listaTareas.RemoveAt(id - 1);
            return Ok();
        }

        
    }
}
