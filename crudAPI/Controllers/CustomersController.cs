using System.Collections.Generic;
using crudAPI.Models;
using crudAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IList<Customer>> GetCustomer()
            => _service.Get();

        [HttpGet("{id:int}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _service.Get(id.ToString());
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            var newCustomer = new Customer(customer);
            _service.Insert(newCustomer);
            return CreatedAtRoute(new {id = newCustomer.Id.ToString()}, newCustomer);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            var updatedCustomer = new Customer(id, customer);
            var customerToUpdate = _service.Get(id.ToString());
            if (customerToUpdate == null)
            {
                return NotFound();
            }
            updatedCustomer.DbId = customerToUpdate.DbId;
            _service.Update(id.ToString(), updatedCustomer);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> DeleteCustomer(int id)
        {
            var customerToUpdate = _service.Get(id.ToString());
            if (customerToUpdate == null)
            {
                return NotFound();
            }            
            _service.Delete(id.ToString());
            return NoContent();
        }
    }
}