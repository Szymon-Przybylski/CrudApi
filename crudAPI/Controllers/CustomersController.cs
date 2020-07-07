using System.Collections.Generic;
using crudAPI.Data.Abstract;
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
        private readonly ICustomersDictionary _dict;
        private readonly CustomerService _service;

        public CustomersController(ICustomersDictionary dict, CustomerService service)
        {
            _dict = dict;
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
            _service.Insert(customer);
            //return CreatedAtRoute("Flavor text here", new {id = customer.Id.ToString()}, customer);
            return Ok();
        }
        
        [HttpPut("{id:int}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            if (!_dict.ContainsCustomer(id)) return NotFound();
            _dict.UpdateCustomer(id, customer);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> DeleteCustomer(int id)
        {
            if (!_dict.ContainsCustomer(id)) return NotFound();
            _dict.RemoveCustomer(id);
            return Ok();
        }
    }
}