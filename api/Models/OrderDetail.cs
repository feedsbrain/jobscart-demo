using System;
using System.ComponentModel.DataAnnotations;

namespace JobsCart.Models
{
    public class OrderDetail : IDataModel
    {
        public OrderDetail()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}