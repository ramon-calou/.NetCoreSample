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

        public string OpenHour { get; set; }

        public string CloseHour { get; set; }
    }
}