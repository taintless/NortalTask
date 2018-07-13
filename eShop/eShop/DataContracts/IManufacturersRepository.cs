using eShop.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IManufacturers
    {
        Task<List<Manufacturer>> GetAll();
    }
}
