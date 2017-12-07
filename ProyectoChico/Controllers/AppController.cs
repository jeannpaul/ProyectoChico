using Microsoft.AspNetCore.Mvc;
using ProyectoChico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoChico.Controllers
{
    public class AppController:Controller
    {
       
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
            return View();
        }

        [HttpGet("Acerca")]
        public IActionResult About()
        {
          

            return View();
        }
    }
}
