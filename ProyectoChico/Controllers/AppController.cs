using Microsoft.AspNetCore.Mvc;
using ProyectoChico.Data;
using ProyectoChico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoChico.Controllers
{
    public class AppController : Controller
    {
        private readonly JotaContext context;
        private readonly IJotaRepository repository;

        public AppController(IJotaRepository repository)
        {
         
            this.repository = repository;
        }
       
        public IActionResult Index()
        {
            
            return View();
        }

        //[HttpGet("Contacto")]
        public IActionResult Contact()
        {
           
           
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactView model)
        {

            if (ModelState.IsValid)
            {

            }
            else
            {

            }
            ViewBag.UserMessage = "Mail enviado";
            return View();
        }

        [HttpGet("Acerca")]
        public IActionResult About()
        {
          

            return View();
        }
        
        [HttpGet("Tienda")]
        public IActionResult Shop()
        {
            var results = repository.obtenerTodo();
            return View(results);

        }
    }
}
