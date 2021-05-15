namespace FruitStore.Domain.DTOs
{
    public class FruitDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
    }
}
