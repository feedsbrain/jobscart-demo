using System.Collections.Generic;

namespace JobsCart.DTOs
{
    public class OrderDetailDto
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public string CustomerId { get; set; }
        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
    }
}