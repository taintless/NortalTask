using eShop.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IManufacturersRepository
    {
        Task<List<Manufacturer>> GetAll();
    }
}
