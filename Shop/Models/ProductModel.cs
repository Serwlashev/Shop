namespace Presentation.Shop.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public CategoryModel Category { get; set; }
        public int Number { get; set; }
    }
}
