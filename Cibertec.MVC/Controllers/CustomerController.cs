using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }

        public IActionResult Edit(int id)
        {
            return View(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Update(customer))
               return RedirectToAction("Index");

            return View(customer);

            
        }

        public IActionResult Delete(int id)
        {
            return View(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            if (customer != null)
            {
                _unit.Customers.Delete(customer);
                return RedirectToAction("Index");
            }
            return View(customer);


        }

        public IActionResult Create()
        {
            var customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer != null)
            {
                _unit.Customers.Insert(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Details(int id)
        {
            return View(_unit.Customers.GetById(id));
        }
    }
}