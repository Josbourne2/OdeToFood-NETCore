﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            //Are you sure you want to delete?
            return Page();
            //Confirm form
        }

        public IActionResult OnPost(int restaurantId)
        {
            //Get restaurant, delete
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();
            //Redirect somewhere
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");


            }
            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");

        }
    }
}