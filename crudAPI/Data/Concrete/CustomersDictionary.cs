using System;
using System.Collections.Generic;
using System.Linq;
using crudAPI.Data.Abstract;

namespace crudAPI.Data.Concrete
{
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

        public Customer GetCustomer(int key)
        {
            try
            {
                return _dict[key];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Customer InsertCustomer(Customer customer)
        {
            var newCustomer = new Customer(customer.CustomerFirstName, customer.CustomerLastName);
            _dict[newCustomer.Id] = newCustomer;
            return customer;
        }
        
        public Customer UpdateCustomer(int key, Customer customer)
        {
            var updatedCustomer = new Customer(key, customer.CustomerFirstName, customer.CustomerLastName);
            _dict[key] = updatedCustomer;
            return customer;
        }

        public void RemoveCustomer(int key)
        {
            _dict.Remove(key);
        }
    }
}