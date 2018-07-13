using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShop.Data.Entities
{
    public class Os
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
