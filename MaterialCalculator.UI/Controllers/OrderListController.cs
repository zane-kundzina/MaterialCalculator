using MaterialCalculator.DAL.Context;
using MaterialCalculator.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Controllers
{
    public class OrderListController : Controller
    {        

        private readonly MaterialCalculatorDBContext _db;

        public OrderListController(MaterialCalculatorDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            //IEnumerable<OrderListDto> objList = _db.OrderList;

            //foreach (var obj in objList)
            //{
            //    obj.Supplier = _db.Suppliers.FirstOrDefault(u => u.Id == obj.SupplierId);
            //}

            return View();
        }

        // GET-Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.OrderList.Select(i => new SelectListItem
            //{
            //    Text = i.OrderNumber,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.TypeDropDown = TypeDropDown;           

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderListDto obj)
        {
            if (ModelState.IsValid)
            {                
                //.OrderList.Add(obj);
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
            //var obj = _db.OrderList.Find(id);
            //if (obj == null)
            //{
            //    return NotFound();
            //}
            return View();

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            //var obj = _db.OrderList.Find(id);
            ////if (obj == null)
            ////{
            ////    return NotFound();
            ////}

            //.OrderList.Remove(obj);
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

            //var obj = _db.OrderList.Find(id);
            ////if (obj == null)
            ////{
            ////    return NotFound();
            ////}
            return View();
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(OrderListDto obj)
        {
            if (ModelState.IsValid)
            {
                //_db.OrderList.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
