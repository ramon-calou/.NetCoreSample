using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantsApi.Models
{
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string name { get; set; }

        public decimal openHour { get; set; }

        public string closeHour { get; set; }
    }
}