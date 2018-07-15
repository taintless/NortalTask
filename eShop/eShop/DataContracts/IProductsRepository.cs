using eShop.Data.Entities;
using eShop.DataContracts.Dtos;
using eShop.DataContracts.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IProductsRepository
    {
        Task<List<int>> GetDifferentStorages();
        Task<List<ProductDto>> GetFiltered(ProductsRequest request);
        Task<Product> GetById(int id);
        Task<double> GetAverageStorage();
        Task<double> GetAverageCamera();
    }
}
