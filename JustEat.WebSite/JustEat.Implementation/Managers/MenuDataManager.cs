namespace JustEat.Implementation.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JustEat.Abstract.DataManagers;
    using JustEat.Core.Models;

    using Newtonsoft.Json;

    public class MenuDataManager : BaseDataManager, IMenuDataManager
    {
        public MenuDataManager(WebClient webClient)
            : base(webClient)
        {
        }

        public async Task<List<MenuItem>> Get(int restaurantId)
        {
            string url = string.Format("restaurants/{0}/menus", restaurantId);
            dynamic result = await this.WebClient.Get<dynamic>(url);
            List<MenuItem> menus = JsonConvert.DeserializeObject<List<MenuItem>>(result.Menus.ToString());

            return menus.ToList();
        }
    }
}
