namespace crudAPI
{
    public class Resource
    {
        private static int _currentResourceId = 1;
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }

        public Resource()
        {
            
        }

        public Resource(string rName)
        {
            ResourceId = _currentResourceId;
            ResourceName = rName;

            _currentResourceId += 1;
        }
    }
}