using System;
using System.ComponentModel.DataAnnotations;
using JobsCart.Models;

namespace JobsCart.DTOs
{
    public class CheckoutDetailDto
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}