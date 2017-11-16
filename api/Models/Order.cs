using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using JobsCart.DAL;

namespace JobsCart.Models
{
    public class Order : IDataModel
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public double TotalPrice
        {
            get
            {
                return OrderDetails.Sum(od => od.Product.Price * od.Quantity);
            }
        }

        public double PriceAfterDiscount { get; set; }
        public double Saving
        {
            get
            {
                return TotalPrice - PriceAfterDiscount;
            }
        }
    }
}