﻿using eShop.DataContracts.Dtos;
using eShop.DataContracts.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DataContracts
{
    public interface IProductsRepository
    {
        Task<List<int>> GetDifferentStorages();
        Task<List<ProductDto>> GetFilteredAsync(ProductsRequest request);
    }
}