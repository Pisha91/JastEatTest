namespace JustEat.Abstract.DataManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JustEat.Core.Models;

    public interface ICategoryDataManager
    {
        Task<List<Category>> Get(int menuId);
    }
}
