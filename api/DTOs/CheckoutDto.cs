using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using JobsCart.DAL;
using JobsCart.Models;

namespace JobsCart.DTOs
{
    public class CheckoutDto
    {
        public IEnumerable<CheckoutDetailDto> OrderDetails { get; set; }
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