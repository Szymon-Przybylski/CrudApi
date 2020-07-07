using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace crudAPI.Data.Abstract
{
    public interface ICustomersDictionary
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(int key);
        Customer InsertCustomer(Customer customer);
        Customer UpdateCustomer(int key, Customer customer);
        void RemoveCustomer(int key);
    }
}