namespace eShop.DataContracts.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ImageLarge { get; set; }
        public string ImageSmall { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Storage { get; set; }
        public int Camera { get; set; }
        public int ManufacturerId { get; set; }
        public int OsId { get; set; }
        public string OsIcon { get; set; }
        public string Description { get; set; }
    }
}
