using AutoMapper;
using eShop.Data.Entities;
using eShop.DataContracts;
using eShop.DataContracts.Dtos;
using eShop.DataContracts.Enums;
using eShop.DataContracts.Requests;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetAverageCamera()
        {
            return await _dbContext.Products
                .AverageAsync(x => x.Camera);
        }

        public async Task<double> GetAverageStorage()
        {
            return await _dbContext.Products
                .AverageAsync(x => x.Storage);
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products
                .SingleAsync(x => x.Id == id);
        }

        public async Task<List<int>> GetDifferentStorages()
        {
            return await _dbContext
                .Products
                .Select(x => x.Storage)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }

        public async Task<List<ProductDto>> GetFilteredAsync(ProductsRequest request)
        {
            var products = _dbContext.Products
                .Include(x => x.Os)
                .Where(x => 
                (request.Storages.Any() ? request.Storages.Any(y => y == x.Storage) : true) 
                && (request.OsesIds.Any() ? request.OsesIds.Any(y => y == x.OsId) : true)
                && (request.ManufacturersIds.Any() ? request.ManufacturersIds.Any(y => y == x.ManufacturerId) : true));

            if (request.Order == ProductsOrder.Alphabetical)
                products = products.OrderBy(x => x.Name);
            if (request.Order == ProductsOrder.PriceHighLow)
                products = products.OrderByDescending(x => x.Price);
            if (request.Order == ProductsOrder.PriceLowHigh)
                products = products.OrderBy(x => x.Price);

            return Mapper.Map<List<ProductDto>>(await products.ToListAsync());
        }
    }
}
