using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ExpenssesTypeController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ExpenssesTypeController(ApplicationDbContext db)
        {
            _db = db;
        }



        // dependcy injections 
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpensesTypes;
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
        public IActionResult Create(ExpenseType obj)
        {

            if (ModelState.IsValid)
            {

                _db.ExpensesTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET delete
        public IActionResult Delete(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpensesTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }


        //Post Delte
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.ExpensesTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.ExpensesTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET update
        public IActionResult Update(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpensesTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
         


        //Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ExpenseType obj)
        {

            if (ModelState.IsValid)
            {
                _db.ExpensesTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}

