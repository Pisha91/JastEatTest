namespace JustEat.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using JustEat.Abstract.DataManagers;
    using JustEat.Core.Models;
    using JustEat.WebSite.Controllers;
    using JustEat.WebSite.ViewModels;

    using Moq;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class GetRestaurantsSteps
    {
        private RestaurantsViewModel restaurantsViewModel;

        private HomeController homeController;

        private ActionResult actionResult;

        /// <summary>
        /// The given i have enter into the input value.
        /// </summary>
        [Given(@"I have entered (.*) into the input")]
        public void GivenIHaveEnterIntoTheInput(string outcode)
        {
            this.restaurantsViewModel = new RestaurantsViewModel { Outcode = outcode };
            var restaurantDataManager = new Mock<IRestaurantDataManager>();
            var menuDataManager = new Mock<IMenuDataManager>();
            var categoryDataManager = new Mock<ICategoryDataManager>();
            var productDataManager = new Mock<IProductDataManager>();

            restaurantDataManager.Setup(x => x.Get(It.Is<string>(y => y == "se19")))
                .Returns(Task.FromResult(new List<Restaurant> { new Restaurant { Logo = new List<Logo>() } }));
            this.homeController = new HomeController(restaurantDataManager.Object, menuDataManager.Object, categoryDataManager.Object, productDataManager.Object);
        }

        [Given(@"I have entered empty value")]
        public void GivenIHaveEnterEmptyValueIntoTheInput()
        {
            this.restaurantsViewModel = new RestaurantsViewModel();
            var restaurantDataManager = new Mock<IRestaurantDataManager>();
            var menuDataManager = new Mock<IMenuDataManager>();
            var categoryDataManager = new Mock<ICategoryDataManager>();
            var productDataManager = new Mock<IProductDataManager>();

            restaurantDataManager.Setup(x => x.Get(It.Is<string>(y => y == "se19")))
                .Returns(Task.FromResult(new List<Restaurant> { new Restaurant { Logo = new List<Logo>() } }));
            this.homeController = new HomeController(restaurantDataManager.Object, menuDataManager.Object, categoryDataManager.Object, productDataManager.Object);
            this.homeController.ModelState.AddModelError("Outcode", "Outcode is required.");
        }

        [When(@"I press button and submit form with valid outcode")]
        public void WhenPressButton()
        {
            this.actionResult = this.homeController.GetRestaurants(this.restaurantsViewModel).Result;
        }

        [Then(@"the result should be PartialView with restaurant list")]
        public void ThenTheResultShouldBePartialViewWithRestaurantList()
        {
            Assert.IsInstanceOf<PartialViewResult>(actionResult);
            Assert.IsNull(((RestaurantsViewModel)(((PartialViewResult)this.actionResult).Model)).Error);
            Assert.IsTrue(((RestaurantsViewModel)(((PartialViewResult)this.actionResult).Model)).Restaurants.Any());
        }

        [Then(@"the result should be JsonResult with Error")]
        public void ThenTheResultShouldBeJsonResultWithError()
        {
            Assert.IsInstanceOf<JsonResult>(actionResult);
            Assert.AreEqual("Post code is invalid.", ((RestaurantsViewModel)(((JsonResult)this.actionResult).Data)).Error);
            Assert.IsNull(((RestaurantsViewModel)(((JsonResult)this.actionResult).Data)).Restaurants);
        }

        [Then(@"the result should be JsonResult with required error")]
        public void ThenTheResultShouldBeJsonResultWithRequiredError()
        {
            Assert.IsInstanceOf<JsonResult>(actionResult);
            Assert.AreEqual("Outcode is required.", ((RestaurantsViewModel)(((JsonResult)this.actionResult).Data)).Error);
            Assert.IsNull(((RestaurantsViewModel)(((JsonResult)this.actionResult).Data)).Restaurants);
        }
    }
}
