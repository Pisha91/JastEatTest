namespace JustEat.Implementation.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JustEat.Abstract.DataManagers;
    using JustEat.Core.Models;

    using Newtonsoft.Json;

    public class ProductDataManager: BaseDataManager, IProductDataManager
    {
        public ProductDataManager(WebClient webClient)
            : base(webClient)
        {
        }

        public async Task<List<Product>> Get(int menuId, int categoryId)
        {
            string url = string.Format("menus/{0}/productcategories/{1}/products", menuId, categoryId);
            dynamic result = await this.WebClient.Get<dynamic>(url);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(result.Products.ToString());

            return products.ToList();
        }
    }
}
