namespace JustEat.WebSite.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using JustEat.Abstract.DataManagers;
    using JustEat.Core.Models;
    using JustEat.WebSite.Mappers;
    using JustEat.WebSite.ViewModels;

    public class HomeController : Controller
    {
        private readonly IRestaurantDataManager restaurantDataManager;

        private readonly IMenuDataManager menuDataManager;

        private readonly ICategoryDataManager categoryDataManager;

        private readonly IProductDataManager productDataManager;

        public HomeController(
            IRestaurantDataManager restaurantDataManager, 
            IMenuDataManager menuDataManager, 
            ICategoryDataManager categoryDataManager, 
            IProductDataManager productDataManager)
        {
            this.restaurantDataManager = restaurantDataManager;
            this.menuDataManager = menuDataManager;
            this.categoryDataManager = categoryDataManager;
            this.productDataManager = productDataManager;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<ActionResult> GetRestaurants(RestaurantsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                List<Restaurant> restaurants = await this.restaurantDataManager.Get(viewModel.Outcode);
                if (restaurants != null && restaurants.Any())
                {
                    viewModel.Restaurants = restaurants.Select(x => x.ToViewModel());

                    return this.PartialView("Partial/RestaurantsPartial", viewModel);
                }

                viewModel.Error = "Post code is invalid.";

                return this.Json(viewModel, JsonRequestBehavior.AllowGet);
            }

            viewModel.Error = "Outcode is required.";

            return this.Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Products(int restaurantId)
        {
            var viewModelList = new List<ProductViewModel>();
            List<MenuItem> menus = await this.menuDataManager.Get(restaurantId);
            foreach (var menuItem in menus)
            {
                List<Category> categories = await this.categoryDataManager.Get(menuItem.Id);
                foreach (var category in categories)
                {
                    List<Product> products = await this.productDataManager.Get(menuItem.Id, category.Id);
                    viewModelList.AddRange(products.Select(x => x.ToViewModel()));
                }
            }

            return this.PartialView("Partial/ProductsPartial", viewModelList);
        }
    }
}