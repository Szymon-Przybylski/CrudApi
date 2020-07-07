using System.Collections.Generic;
using System.Collections.ObjectModel;
using crudAPI.Models;
using Microsoft.AspNetCore.Http;

namespace crudAPI.Data.Abstract
{
    public interface ICustomersDictionary
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(int key);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(int key, Customer customer);
        void RemoveCustomer(int key);
        bool ContainsCustomer(int key);
    }
}