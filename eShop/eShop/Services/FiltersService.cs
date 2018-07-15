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
            var manufacturers = _manufacturersRepository.GetAll();
            var oses = _osesRepository.GetAll();
            var storages = _productsRepository.GetDifferentStorages();
            var averageStorage = _productsRepository.GetAverageStorage();
            var averageCamera = _productsRepository.GetAverageCamera();

            return new FiltersDto
            {
                Manufacturers = await manufacturers,
                Oses = await oses,
                Storages = await storages,
                AvgCamera = await averageCamera,
                AvgStorage = await averageStorage
            };
        }
    }
}
