using eShop.Data.Entities;
using System.Collections.Generic;

namespace eShop.DataContracts.Dtos
{
    public class FiltersDto
    {
        public List<Os> Oses { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<int> Storages { get; set; }
        public double AvgCamera { get; set; }
        public double AvgStorage { get; set; }
    }
}
