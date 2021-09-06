namespace Core.Domain.Entity
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public int Number { get; set; }
    }
}
