using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using crudAPI.Data.Abstract;
using crudAPI.Models;

namespace crudAPI.Data.Concrete
{
    public class CustomersDictionary : ICustomersDictionary
    {
        private IDictionary<int, Customer> _dict = new Dictionary<int, Customer>();


        public CustomersDictionary()
        {
            var resources = new Collection<Resource> {new Resource("copper")};
            _dict.Add(1, new Customer("Edith", "Finch", resources));
        }

        public IList<Customer> GetCustomers()
        {
            return _dict.Select(customer => customer.Value).ToList();
        }

        public Customer GetCustomer(int key)
        {
            return _dict[key];
        }

        public void InsertCustomer(Customer customer)
        {
            var newCustomer = new Customer(customer.CustomerFirstName, customer.CustomerLastName);
            _dict[newCustomer.Id] = newCustomer;
        }
        
        public void UpdateCustomer(int key, Customer customer)
        {
            var updatedCustomer = new Customer(key, customer.CustomerFirstName, customer.CustomerLastName);
            _dict[key] = updatedCustomer;
        }

        public void RemoveCustomer(int key)
        {
            _dict.Remove(key);
        }

        public bool ContainsCustomer(int key)
        {
            return _dict.ContainsKey(key);
        }
    }
}