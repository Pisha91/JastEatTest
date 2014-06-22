namespace JustEat.WebSite.Mappers
{
    using JustEat.Core.Models;
    using JustEat.WebSite.ViewModels;

    using Omu.ValueInjecter;

    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(this Product model)
        {
            var viewModel = new ProductViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }
    }
}