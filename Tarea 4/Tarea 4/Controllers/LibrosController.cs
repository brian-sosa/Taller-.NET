using Microsoft.AspNetCore.Mvc;
using Tarea_4.Models.Libro;

namespace MyApp.Namespace
{

    public class LibrosController : Controller
    {
        private readonly ILogger<LibrosController> _logger;
        private readonly LibroService _libroService;

        public LibrosController(ILogger<LibrosController> logger, LibroService _libroService)
        {
            _logger = logger;
            this._libroService = _libroService;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public IActionResult GetLibros()
        {
            return View("List", _libroService.GetAll());
        }

       
        public IActionResult CreateLibro()
        {
            return View("Create");
        }

        [HttpPost("DeleteLibro/{id}")]
        public IActionResult DeleteLibro(string id)
        {
            _libroService.Delete(id);

            return View("List", _libroService.GetAll());
        }

        [HttpPost("AddLibro")]
        public IActionResult AddLibro(Libro libro)
        {
            _libroService.Add(libro);
            return View("List", _libroService.GetAll());
        }


        public IActionResult UpdateLibroView(string id)
        {
            return View("Update", _libroService.GetById(id));
        }
        
        public IActionResult UpdateLibro(Libro libro, string id)
        {
            _libroService.Update(libro, id);
            return View("List", _libroService.GetAll());
        }
    }
}
