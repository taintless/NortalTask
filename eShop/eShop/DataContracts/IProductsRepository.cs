using eShop.Data.Entities;
using eShop.DataContracts.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IProductsRepository
    {
        Task<List<int>> GetDifferentStorages();
        Task<List<Product>> GetFilteredAsync(ProductsRequest request);
    }
}
