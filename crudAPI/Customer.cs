using System.Collections.Generic;

namespace crudAPI
{
    public class Customer
    {
        private static int _currentCustomerId = 1;
        public int Id { get; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public IList<Resource> CustomerResources { get; set; }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            Id = _currentCustomerId;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            CustomerResources = new List<Resource>();

            _currentCustomerId += 1;
        }
    }
}