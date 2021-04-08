using RestaurantsApi.Models;
using RestaurantsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RestaurantsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantsController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public ActionResult<List<Restaurant>> Get() =>
            _restaurantService.Get();

        [HttpGet("{id:length(24)}", Name = "GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Restaurant> Get(string id)
        {
            var restaurant = _restaurantService.Get(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpGet("{time:length(4)}", Name = "GetRestaurantByTime")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         public ActionResult<List<Restaurant>> GetByTime(string time)
        {
            var restaurant = _restaurantService.GetByTime(time);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Restaurant> Create(Restaurant restaurant)
        {
            _restaurantService.Create(restaurant);

            return CreatedAtRoute("GetRestaurant", new { id = restaurant.Id.ToString() }, restaurant);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Restaurant restaurantIn)
        {
            var restaurant = _restaurantService.Get(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantService.Update(id, restaurantIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var restaurant = _restaurantService.Get(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantService.Remove(restaurant.Id);

            return NoContent();
        }
    }
}