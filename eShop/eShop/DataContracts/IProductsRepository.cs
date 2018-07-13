using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IProductsRepository
    {
        Task<List<int>> GetDifferentStorages();
    }
}
