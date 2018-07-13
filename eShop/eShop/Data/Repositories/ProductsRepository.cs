﻿using AutoMapper;
using eShop.Data.Entities;
using eShop.DataContracts;
using eShop.DataContracts.Dtos;
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
            var products = new List<Product>();

            if (request.ManufacturersIds.Count() == 0
                && request.OsesIds.Count() == 0
                && request.Storages.Count() == 0)
                products = await _dbContext.Products.ToListAsync();
            else
                products = await _dbContext.Products
                    .Where(x => request.Storages.Any(y => y == x.Storage) || request.OsesIds.Any(y => y == x.OsId) || request.ManufacturersIds.Any(y => y == x.ManufacturerId))
                    .ToListAsync();

                return Mapper.Map<List<ProductDto>>(products);
        }
    }
}