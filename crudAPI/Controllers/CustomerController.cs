using System.Collections.Generic;
using crudAPI.Data;
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
        public ActionResult<Customer> AddCustomer(string firstName, string lastName)
        {
            var customer = _dict.InsertCustomer(firstName, lastName);
            return Ok(customer);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult<Customer> UpdateCustomer(int id, string firstName, string lastName)
        {
            var customer = _dict.UpdateCustomer(id, firstName, lastName);
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> DeleteCustomer(int id)
        {
            _dict.RemoveCustomer(id);
            return Ok();
        }
    }
}