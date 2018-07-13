using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eShop.ServiceContracts;

namespace eShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFiltersService _filtersService;

        public HomeController(IFiltersService filtersService)
        {
            _filtersService = filtersService;
        }
        public async Task<IActionResult> Index()
        {
            var filters = await _filtersService.GetAll();

            return View(filters);
        }
    }
}
