using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurant;

        public InMemoryRestaurantData()
        {
            _restaurant = new List<Restaurant> {
                new Restaurant { Id = 1, Name = "kike's restaurant" },
                new Restaurant { Id = 2, Name = "Little caesar" },
                new Restaurant { Id = 3, Name = "Chilis" }
            };
        }

        public Restaurant Get(int id)
        {
            return _restaurant.FirstOrDefault(item=>item.Id==id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurant.OrderBy(r => r.Name);
        }

        Restaurant IRestaurantData.Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurant.Max(r=>r.Id +1);
            _restaurant.Add(newRestaurant);
            return newRestaurant;
        }
    }
}
