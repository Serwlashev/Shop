namespace Domain.Entity
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Number { get; set; }
    }
}
