using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class itemController : Controller
    {

        private readonly ApplicationDbContext _db;


        public itemController(ApplicationDbContext db)
        {
            _db= db;
        }

         

        // dependcy injections 
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items; 
            return View(objList);
        }

        //GET create 
        public IActionResult Create()
        {
            return View();
        }

        //POST Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {

            if (ModelState.IsValid) {
                _db.Items.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);   
        }
  


    }
}
