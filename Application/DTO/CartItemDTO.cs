using System;

namespace Core.Application.DTO
{
    public class CartItemDTO
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
