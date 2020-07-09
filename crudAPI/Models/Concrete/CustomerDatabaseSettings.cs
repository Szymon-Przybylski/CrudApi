using crudAPI.Models.Abstract;

namespace crudAPI.Models.Concrete
{
    public class CustomerDatabaseSettings : ICustomerDatabaseSettings
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}