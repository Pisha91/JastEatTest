using Ninject;

namespace JustEat.SetUp
{
    using System.Net;

    using JustEat.Abstract.DataManagers;
    using JustEat.Implementation.Managers;

    public class DependencyInjectionManager
    {
        public void SetUp(IKernel kernel)
        {
            kernel.Bind<WebClient>().ToSelf();
            kernel.Bind<IRestaurantDataManager>().To<RestaurantDataManager>();
            kernel.Bind<IMenuDataManager>().To<MenuDataManager>();
            kernel.Bind<ICategoryDataManager>().To<CategoryDataManager>();
            kernel.Bind<IProductDataManager>().To<ProductDataManager>();
        }
    }
}
