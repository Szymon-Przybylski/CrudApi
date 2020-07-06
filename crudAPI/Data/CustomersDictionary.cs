using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace crudAPI.Data
{
    public interface ICustomersDictionary
    {
        IList<Customer> GetCustomers();
    }
    
    public class CustomersDictionary : ICustomersDictionary
    {
        private IDictionary<int, Customer> _dict = new Dictionary<int, Customer>();


        public CustomersDictionary()
        {
            _dict.Add(1, new Customer("Edith", "Finch"));
        }

        public IList<Customer> GetCustomers()
        {
            return _dict.Select(customer => customer.Value).ToList();
        }

    }
}