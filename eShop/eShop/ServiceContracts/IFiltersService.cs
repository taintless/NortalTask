using eShop.DataContracts.Dtos;
using System.Threading.Tasks;

namespace eShop.ServiceContracts
{
    public interface IFiltersService
    {
        Task<FiltersDto> GetAll();
    }
}
