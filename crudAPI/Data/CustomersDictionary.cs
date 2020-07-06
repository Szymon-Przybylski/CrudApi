using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace crudAPI.Data
{
    public interface ICustomersDictionary
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(int key);
        Customer InsertCustomer(string firstName, string lastName);
        Customer UpdateCustomer(int key, string firstName, string lastName);
        void RemoveCustomer(int key);
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

        public Customer InsertCustomer(string firstName, string lastName)
        {
            Customer customer = new Customer(firstName, lastName);
            //return customer;
            _dict[customer.Id] = customer;
            return customer;
        }
        
        public Customer UpdateCustomer(int key, string firstName, string lastName)
        {
            Customer customer = _dict[key];
            customer.CustomerFirstName = firstName;
            customer.CustomerLastName = lastName;
            _dict[key] = customer;
            return customer;
        }

        public void RemoveCustomer(int key)
        {
            _dict.Remove(key);
        }
    }
}