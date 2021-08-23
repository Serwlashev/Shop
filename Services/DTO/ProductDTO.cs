namespace Services.DTO
{
    class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryDTO Category { get; set; }
        public int Number { get; set; }
    }
}
