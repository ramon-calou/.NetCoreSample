namespace RestaurantsApi.Models
{
    public class RestaurantStoreDatabaseSettings : IRestaurantStoreDatabaseSettings
    {
        public string RestaurantsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRestaurantStoreDatabaseSettings
    {
        string RestaurantsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}