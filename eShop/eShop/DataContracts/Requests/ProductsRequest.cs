using eShop.DataContracts.Enums;
using System.Collections.Generic;

namespace eShop.DataContracts.Requests
{
    public class ProductsRequest
    {
        public ProductsRequest()
        {
            ManufacturersIds = new List<int>();
            OsesIds = new List<int>();
            Storages = new List<int>();
        }
        public List<int> ManufacturersIds { get; set; }
        public List<int> OsesIds { get; set; }
        public List<int> Storages { get; set; }
        public ProductsOrder Order { get; set; }
    }
}
