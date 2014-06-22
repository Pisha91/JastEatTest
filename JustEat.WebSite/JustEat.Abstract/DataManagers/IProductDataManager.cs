namespace JustEat.Abstract.DataManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JustEat.Core.Models;

    public interface IProductDataManager
    {
        Task<List<Product>> Get(int menuId, int categoryId);
    }
}
