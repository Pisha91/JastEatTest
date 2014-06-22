namespace JustEat.Abstract.DataManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JustEat.Core.Models;

    public interface IRestaurantDataManager
    {
        Task<List<Restaurant>> Get(string outcode);
    }
}
