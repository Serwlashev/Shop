using System.Collections.Generic;

namespace Shop.Models
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
