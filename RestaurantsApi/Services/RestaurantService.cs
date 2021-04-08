using RestaurantsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
namespace RestaurantsApi.Services
{
    public class RestaurantService
    {
        private readonly IMongoCollection<Restaurant> _restaurants;

        public RestaurantService(IRestaurantStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _restaurants = database.GetCollection<Restaurant>(settings.RestaurantsCollectionName);
        }

        public List<Restaurant> Get() =>
            _restaurants.Find(restaurant => true).ToList();

        public List<Restaurant> GetByTime(string time) {
            var timeCompare = int.Parse(time.Substring(0,4));
            return _restaurants.Find<Restaurant>(restaurant =>
             (restaurant.OpenHour <= timeCompare) && (restaurant.CloseHour >= timeCompare)).ToList();
        }
            
        public Restaurant Get(string id) =>
            _restaurants.Find<Restaurant>(restaurant => restaurant.Id == id).FirstOrDefault();

        public Restaurant Create(Restaurant restaurant)
        {
            _restaurants.InsertOne(restaurant);
            return restaurant;
        }

        public void Update(string id, Restaurant restaurantIn) =>
            _restaurants.ReplaceOne(restaurant => restaurant.Id == id, restaurantIn);

        public void Remove(Restaurant restaurantIn) =>
            _restaurants.DeleteOne(restaurant => restaurant.Id == restaurantIn.Id);

        public void Remove(string id) => 
            _restaurants.DeleteOne(restaurant => restaurant.Id == id);
    }
}