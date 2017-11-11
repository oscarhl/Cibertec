using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{    
    [Route("api/Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                return Ok(_unit.Customers.Insert(customer));
            }
            return BadRequest(ModelState);
            
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Update(customer))
            {
                return Ok(new { Message="The Customer is Updated" });
            }
            return BadRequest(ModelState);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id.HasValue && id.Value>0)
            {
                return Ok(_unit.Customers.Delete(new Customer { Id=id.Value}));
            }
            return BadRequest(new { Message="Incorrect data"});

        }
    }
}