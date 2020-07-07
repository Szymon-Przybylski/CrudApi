using System.Collections.Generic;
using crudAPI.Data.Abstract;
using crudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudAPI.Controllers
{

    [ApiController]
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private ICustomersDictionary _dict;

        public CustomerController(ICustomersDictionary dict)
        {
            _dict = dict;
        }

        [HttpGet]
        public ActionResult<IList<Customer>> GetCustomer()
        {
            var customers = _dict.GetCustomers();
            return Ok(customers);
        }
        
        [HttpGet("{id:int}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _dict.GetCustomer(id);
            return Ok(customer);
        }
        
        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            _dict.InsertCustomer(customer);
            return StatusCode(StatusCodes.Status201Created);
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