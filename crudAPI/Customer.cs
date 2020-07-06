using System.Collections.Generic;

namespace crudAPI
{
    public class Customer
    {
        private static int _currentCustomerId = 1;
        private int Id { get; set; }
        private string CustomerFirstName { get; set; }
        private string CustomerLastName { get; set; }
        private IList<Resource> CustomerResources { get; set; }

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