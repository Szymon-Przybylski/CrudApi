using System.Collections.Generic;
using crudAPI.Models;
using crudAPI.Models.Abstract;
using MongoDB.Driver;

namespace crudAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(ICustomerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get() 
            => _customers.Find(customer => true).ToList();

        public Customer Get(string customerId)
            => _customers.Find<Customer>(customer => customer.Id == int.Parse(customerId)).FirstOrDefault();

        public Customer Insert(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public void Update(string customerId, Customer updatedCustomer)
        {
            _customers.ReplaceOne(customer => customer.Id == int.Parse(customerId), updatedCustomer);
        }

        public void Delete(string customerId)
        {
            _customers.DeleteOne(customer => customer.Id == int.Parse(customerId));
        }
    }
}