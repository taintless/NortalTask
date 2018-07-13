using eShop.DataContracts;
using eShop.DataContracts.Dtos;
using eShop.ServiceContracts;
using System.Threading.Tasks;

namespace eShop.Services
{
    public class FiltersService : IFiltersService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IManufacturersRepository _manufacturersRepository;
        private readonly IOsesRepository _osesRepository;

        public FiltersService(IManufacturersRepository manufacturersRepository, IOsesRepository osesRepository, IProductsRepository productsRepository)
        {
            _manufacturersRepository = manufacturersRepository;
            _osesRepository = osesRepository;
            _productsRepository = productsRepository;
        }

        public async Task<FiltersDto> GetAll()
        {
            var manufacturers = await _manufacturersRepository.GetAll();
            var oses = await _osesRepository.GetAll();
            var storages = await _productsRepository.GetDifferentStorages();

            return new FiltersDto
            {
                Manufacturers = manufacturers,
                Oses = oses,
                Storages = storages
            };
        }
    }
}
