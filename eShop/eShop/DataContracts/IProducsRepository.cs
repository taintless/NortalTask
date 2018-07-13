using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IProducsRepository
    {
        Task<List<int>> GetDifferentStorages();
    }
}
