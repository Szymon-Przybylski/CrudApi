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
            var c1 = new Customer("Edith", "Finch");
            return c1;
        }
        
        [HttpPost]
        public ActionResult<Customer> AddCustomer()
        {
            return new Customer("Samantha", "Greenbriar");
        }
        
        [HttpPut("{id:int}")]
        public ActionResult<Customer> UpdateCustomer(int id)
        {
            return new Customer("Jesse", "Faden");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> DeleteCustomer(int id)
        {
            return $"Well, customer {id} will not bother us again, will she?";
        }
    }
}