using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; } //Waarom nog een getter en setter hier?

        public ListModel(ILogger<IndexModel> logger, IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;            
            this.restaurantData = restaurantData;
            _logger = logger;
        }

        public void OnGet() //string searchTerm parameter komt overeen met naam van het search form
        {
            //HttpContext.Request.QueryString kan, maar er is een beter manier..
            //Message = config["Message"];
            //Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            _logger.LogInformation("Getting restaurants!");
        }
    }
}