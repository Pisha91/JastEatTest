namespace JustEat.Implementation.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JustEat.Abstract.DataManagers;
    using JustEat.Core.Models;

    using Newtonsoft.Json;

    public class CategoryDataManager : BaseDataManager, ICategoryDataManager
    {
        public CategoryDataManager(WebClient webClient)
            : base(webClient)
        {
        }

        public async Task<List<Category>> Get(int menuId)
        {
            string url = string.Format("menus/{0}/productcategories", menuId);
            dynamic result = await this.WebClient.Get<dynamic>(url);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(result.Categories.ToString());

            return categories.ToList();
        }
    }
}
