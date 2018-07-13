using eShop.Data.Entities;
using eShop.DataContracts;
using eShop.DataContracts.Requests;
using eShop.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task<List<Product>> GetFiltered(ProductsRequest request)
        {
            return _productsRepository.GetFilteredAsync(request);
        }
    }
}
