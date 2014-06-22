namespace JustEat.Implementation.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JustEat.Abstract.DataManagers;
    using JustEat.Core.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// The restaurant data manager.
    /// </summary>
    public class RestaurantDataManager : BaseDataManager, IRestaurantDataManager
    {
        public RestaurantDataManager(WebClient webClient)
            : base(webClient)
        {
        }

        public async Task<List<Restaurant>> Get(string outcode)
        {
            string url = string.Format("restaurants?q={0}", outcode);
            dynamic result = await this.WebClient.Get<dynamic>(url);
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(result.Restaurants.ToString());

            return restaurants.OrderByDescending(x => x.RatingStars).ToList();
        }
    }
}
