using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace crudAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DbId { get; set; }
        
        private static int _currentCustomerId = 1;
        
        [BsonElement("customerId")]
        public int Id { get; }
        [BsonElement("firstName")]
        public string CustomerFirstName { get; set; }
        [BsonElement("lastName")]
        public string CustomerLastName { get; set; }
        [BsonElement("resources")]
        public Collection<Resource> CustomerResources { get; set; }

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
        public Customer(string firstName, string lastName, Collection<Resource> resources)
        {
            Id = _currentCustomerId;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            CustomerResources = resources;

            _currentCustomerId += 1;
        }
        public Customer(Customer c)
        {
            Id = _currentCustomerId;
            CustomerFirstName = c.CustomerFirstName;
            CustomerLastName = c.CustomerLastName;
            CustomerResources = new Collection<Resource>();

            _currentCustomerId += 1;
        }
    }
}