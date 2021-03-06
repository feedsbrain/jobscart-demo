using System.Collections.Generic;
using System.Linq;
using CryptoHelper;
using JobsCart.DAL;
using JobsCart.DTOs;
using JobsCart.Helpers;
using JobsCart.Models;

namespace JobsCart.Services
{
    public interface ICheckoutService
    {
        Order Checkout(OrderDto orderDto);
    }

    public class CheckoutService : ICheckoutService
    {
        private JobsDbContext _context;

        public CheckoutService(JobsDbContext context)
        {
            _context = context;
        }

        public Order Checkout(OrderDto orderDto)
        {
            var order = new Order();

            var customer = _context.Customers.First(c => c.UserName == orderDto.CustomerId);
            _context.Entry(customer).Collection(c => c.PriceRules).Load();
            
            order.Customer = customer;
            var orderDetails = new List<OrderDetail>();
            foreach (var od in orderDto.OrderDetails)
            {
                var d = new OrderDetail();
                var p = _context.Products.First(x => x.Id == od.ProductId);
                d.Order = order;
                d.Product = p;
                d.Quantity = od.Quantity;
                orderDetails.Add(d);
            }
            order.OrderDetails = orderDetails;

            // Calculate Discount
            var co = new Checkout(customer.PriceRules != null && customer.PriceRules.Any() ? new HashSet<PriceRule>(customer.PriceRules) : new HashSet<PriceRule>());
            co.Add(order);
            order.PriceAfterDiscount = co.Total();

            return order;
        }
    }

}