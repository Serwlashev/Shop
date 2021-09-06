using System.Collections.Generic;

namespace Core.Domain.Entity
{
    public class Category : BaseEntity<long>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
