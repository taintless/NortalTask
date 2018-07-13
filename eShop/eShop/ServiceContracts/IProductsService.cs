using eShop.Data.Entities;
using eShop.DataContracts.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.ServiceContracts
{
    public interface IProductsService
    {
        Task<List<Product>> GetFiltered(ProductsRequest request);
    }
}
