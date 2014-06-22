namespace JustEat.Abstract.DataManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JustEat.Core.Models;

    /// <summary>
    /// The MenuDataManager interface.
    /// </summary>
    public interface IMenuDataManager
    {
        Task<List<MenuItem>> Get(int restaurantId);
    }
}
