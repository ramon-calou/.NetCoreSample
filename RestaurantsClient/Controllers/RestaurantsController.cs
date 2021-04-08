using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using RestaurantsClient.Models;
using Newtonsoft.Json;

namespace RestaurantsClient.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ILogger<RestaurantsController> _logger;

        public RestaurantsController(ILogger<RestaurantsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

         public IActionResult Upload()
        {
            return View();
        }

         public async Task<ActionResult> getRestaurantsDataJson(String time)
        {
            try
            {
                string Url = "https://localhost:5001/api/Restaurants/" + time;
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(Url);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var apiResult = JsonConvert.DeserializeObject<List<Restaurant>>(apiResponse);
                var jsonResult = Json(apiResult);
                return jsonResult;
            }
            catch
            {
                throw new Exception("Não foi possível pegar os dados da API");
            }            
        }
        
        public async Task<IActionResult> processCsv(IFormFile file)
        {
            List<Restaurant> restaurantsUpload = new List<Restaurant>();
            try{
                if (file.FileName.EndsWith(".csv"))
                {
                    using (var sreader = new StreamReader(file.OpenReadStream()))
                    {
                        string[] headers = sreader.ReadLine().Split(',');     
                        while (!sreader.EndOfStream)                          
                        {
                            Restaurant restaurant = new Restaurant();
                            string[] rows = sreader.ReadLine().Split(',');
                            restaurant.name = rows[0].ToString();
                            String[] openCloseHour = (rows[1].ToString()).Split('-');
                            restaurant.OpenHour = int.Parse(openCloseHour[0].Replace(":", ""));
                            restaurant.CloseHour = int.Parse(openCloseHour[1].Replace(":", ""));
                            restaurantsUpload.Add(restaurant);
                        }
                    }
                    return null;
                }
                else
                {
                    return null;
                }             
            }catch{
                throw new Exception("Ocorreu um erro ao realizar o processamento dos dados");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
