using System.Collections.Generic;

namespace crudAPI
{
    public class Customer
    {
        private static int _currentCustomerId = 1;
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public List<Resource> CustomerResources { get; set; }

        public Customer()
        {

        }

        public Customer(string fName, string lName)
        {
            CustomerId = _currentCustomerId;
            CustomerFirstName = fName;
            CustomerLastName = lName;
            CustomerResources = new List<Resource>();

            _currentCustomerId += 1;
        }
    }
}