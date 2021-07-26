using MaterialCalculator.DAL.Context;
using MaterialCalculator.Entity;
using MaterialCalculator.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly MaterialCalculatorDBContext _db;

        public SupplierController(MaterialCalculatorDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<SupplierDto> objList = _db.Suppliers;
            return View(objList);

        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupplierDto obj)
        {
            if (ModelState.IsValid)
            {
                _db.Suppliers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        // GET Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Suppliers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Suppliers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Suppliers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Suppliers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SupplierDto obj)
        {
            if (ModelState.IsValid)
            {
                _db.Suppliers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
