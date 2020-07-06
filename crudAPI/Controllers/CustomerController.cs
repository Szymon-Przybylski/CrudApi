using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace crudAPI.Controllers
{

    [ApiController]
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private ILog _log;

        public CustomerController(ILog log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.Info("Currently here");
            return View();
        }
        
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomer()
        {
            var  customers = new List<Customer>();
            var c1 = new Customer("Edith", "Finch");
            customers.Add(c1);
            return customers;
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