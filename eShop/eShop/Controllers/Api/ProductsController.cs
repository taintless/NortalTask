using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.DataContracts.Requests;
using eShop.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult GetAll([FromQuery]ProductsRequest request)
        {
            return Ok(_productsService.GetFiltered(request));
        }
    }
}