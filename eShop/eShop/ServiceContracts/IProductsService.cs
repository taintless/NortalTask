using eShop.Data.Entities;
using eShop.DataContracts.Dtos;
using eShop.DataContracts.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.ServiceContracts
{
    public interface IProductsService
    {
        Task<List<ProductDto>> GetFiltered(ProductsRequest request);
        Task<Product> GetById(int id);
    }
}
