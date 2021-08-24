namespace Shop.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryViewModel Category { get; set; }
        public int Number { get; set; }
    }
}
