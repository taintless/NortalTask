using System.ComponentModel.DataAnnotations;

namespace eShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string ImageLarge { get; set; }
        [MaxLength(50)]
        public string ImageSmall { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Storage { get; set; }
        public int Camera { get; set; }
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Os Os { get; set; }
    }
}
