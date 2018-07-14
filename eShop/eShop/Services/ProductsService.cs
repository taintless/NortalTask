using eShop.DataContracts;
using eShop.DataContracts.Dtos;
using eShop.DataContracts.Requests;
using eShop.ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public Task<List<ProductDto>> GetFiltered(ProductsRequest request)
        {
            return _productsRepository.GetFilteredAsync(request);
        }
    }
}
