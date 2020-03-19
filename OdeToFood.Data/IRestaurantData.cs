using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Jos's Resto", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant{Id=2, Name="Jackrabbit Slim's",Location="Utrecht",Cuisine=CuisineType.Indian},
                new Restaurant{Id=3, Name="Big Kahuna Burger", Location="Mexico", Cuisine=CuisineType.Mexican}
            };

        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return restaurants;
            return from r in restaurants
                   orderby r.Name
                   select r;

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }
    }
}
