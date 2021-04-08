using System;
namespace RestaurantsClient.Models
{
    public class Restaurant
    {
        
        public string name { get; set; }
        
        public int OpenHour { get; set; }
        public int CloseHour { get; set; }
    }
}