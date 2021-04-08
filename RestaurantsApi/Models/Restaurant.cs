using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RestaurantsApi.Models
{
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string name { get; set; }

        public int OpenHour { get; set; }

        public int CloseHour { get; set; }
    }
}