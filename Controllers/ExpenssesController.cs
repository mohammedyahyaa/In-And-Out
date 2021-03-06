using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Controllers
{
    public class ExpenssesController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ExpenssesController(ApplicationDbContext db)
        {
            _db = db;
        }



        // dependcy injections 
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;

            foreach (var obj in objList)
            {
                obj.ExpenseType = _db.ExpensesTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }
            return View(objList);
        }

        //GET create 
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> typeDropDown = _db.ExpensesTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString(),    
            //});
            ExpensesVm expenseVM = new ExpensesVm()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpensesTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })

            };

            // ViewBag.TypeDropDown = typeDropDown;
            return View(expenseVM);
        }

        //POST Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpensesVm obj)
        {
            if (ModelState.IsValid)
            {
                // obj.ExpenseTypeId = 2;
                _db.Expenses.Add(obj.Expense);
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

            var obj = _db.Expenses.Find(id);
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

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET update
        public IActionResult Update(int? id)
        {

            ExpensesVm expenseVM = new ExpensesVm()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpensesTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })

            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            expenseVM.Expense = _db.Expenses.Find(id);
            if (expenseVM.Expense == null)
            {
                return NotFound();
            }
            return View(expenseVM);

        }

        //Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ExpensesVm obj)
        {

            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}

