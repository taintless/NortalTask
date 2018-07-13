using eShop.Data.Entities;
using eShop.DataContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Data.Repositories
{
    public class ManufacturersRepository : IManufacturersRepository
    {
        private readonly AppDbContext _dbContext;

        public ManufacturersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Manufacturer>> GetAll()
        {
            return await _dbContext.Manufacturers
                .ToListAsync();
        }
    }
}
