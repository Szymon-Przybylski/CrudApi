using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace crudAPI
{
    public class Customer
    {
        private static int _currentCustomerId = 1;
        public int Id { get; }
        public string CustomerFirstName { get; }
        public string CustomerLastName { get; }
        public Collection<Resource> CustomerResources { get; }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            Id = _currentCustomerId;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            CustomerResources = new Collection<Resource>();

            _currentCustomerId += 1;
        }
        public Customer(int desiredId, string firstName, string lastName)
        {
            Id = desiredId;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            CustomerResources = new Collection<Resource>();
        }
        public Customer(string firstName, string lastName, Collection<Resource> resources)
        {
            Id = _currentCustomerId;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            CustomerResources = resources;

            _currentCustomerId += 1;
        }
    }
}