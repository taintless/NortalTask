using eShop.DataContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data
{
    public class ProductsRepository : IProducsRepository
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
                .ToListAsync();
        }
    }
}
