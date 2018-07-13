using eShop.Data.Entities;
using eShop.DataContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Data.Repositories
{
    public class OsesRepository :IOsesRepository
    {
        private readonly AppDbContext _dbContext;

        public OsesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Os>> GetAll()
        {
            return await _dbContext
                .Oses
                .ToListAsync();
        }
    }
}
