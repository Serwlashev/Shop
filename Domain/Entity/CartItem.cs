using System;

namespace Core.Domain.Entity
{
    public class CartItem : BaseEntity<long>
    {
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
