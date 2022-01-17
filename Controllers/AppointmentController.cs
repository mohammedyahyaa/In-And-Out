using Microsoft.AspNetCore.Mvc;
using System;

namespace InAndOut.Controllers
{

    [Route("Admin/[controller]")] 
    public class AppointmentController : Controller

        
    {

        [Route("main")]
        public IActionResult Index()
        {
          // return NotFound();
            return View();
          
        }


        [Route("details/{id}")]
        public IActionResult details(int id)
        {
            return Ok("you have entered : {id} "+id); 

        }
    }
}
