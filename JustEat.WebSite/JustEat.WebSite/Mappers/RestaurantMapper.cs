namespace JustEat.WebSite.Mappers
{
    using System.Linq;

    using JustEat.Core.Models;
    using JustEat.WebSite.ViewModels;

    using Omu.ValueInjecter;

    public static class RestaurantMapper
    {
        public static RestaurantViewModel ToViewModel(this Restaurant model)
        {
            var viewModel = new RestaurantViewModel();
            viewModel.InjectFrom(model);
            viewModel.AvarageRating = model.RatingStars;
            viewModel.Logo = model.Logo.FirstOrDefault() != null
                                 ? model.Logo.First().StandardResolutionURL
                                 : string.Empty;

            return viewModel;
        }
    }
}