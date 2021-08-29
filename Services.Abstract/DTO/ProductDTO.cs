namespace Services.Abstract.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public CategoryDTO Category { get; set; }
        public int Number { get; set; }
    }
}
