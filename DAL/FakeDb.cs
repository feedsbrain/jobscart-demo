using System;
using System.Collections.Generic;
using JobsCart.Models;

namespace JobsCart.DAL {
    public class FakeDb : IDisposable {
        void IDisposable.Dispose () {
            // Disposable Pattern
        }

        public List<Product> products = new List<Product> {
            new Product { Id = "classic", Name = "Classic Ad", Description = "Offers the most basic level of advertisement", Price = 269.99 },
            new Product { Id = "standout", Name = "Standout Ad", Description = "Allows advertisers to use a company logo and use a longer presentation text", Price = 322.99 },
            new Product { Id = "premium", Name = "Premium Ad", Description = "Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility", Price = 394.99 }
        };

        public List<Pricing> pricings = new List<Pricing> {
            new Pricing { Id = "3for2classic", ProductId = "classic", Description = "Gets a 3 for 2 deals on Classic Ads", MinQuantity = 3, BonusQuantity = 1 },
            new Pricing { Id = "fixedprice2", ProductId = "standout", Description = "Gets a discount on Standout Ads where the price drops to $299.99 per ad", MinQuantity = 1, Price = 299.99 },
            new Pricing { Id = "4ormore", ProductId = "premium", Description = "Gets a discount on Premium Ads where 4 or more are purchased. The price drops to $379.99 per ad", MinQuantity = 4, Price = 379.99 },
            new Pricing { Id = "5for4classic", ProductId = "classic", Description = "Gets a 5 for 4 deal on Classic Ads", MinQuantity = 5, BonusQuantity = 1 },
            new Pricing { Id = "fixedprice3", ProductId = "standout", Description = "Gets a discount on Standout Ads where the price drops to $309.99 per ad", MinQuantity = 1, Price = 309.99 },
            new Pricing { Id = "3ormore", ProductId = "premium", Description = "Gets a discount on Premium Ads when 3 or more are purchased. The price drops to $389.99 per ad", MinQuantity = 3, Price = 389.99 }
        };

        public List<Customer> customers = new List<Customer> {
            new Customer { LoginId = "unilever", PricingIds = new List<string> { "3for2classic" } },
            new Customer { LoginId = "apple", PricingIds = new List<string> { "fixedprice2" } },
            new Customer { LoginId = "nike", PricingIds = new List<string> { "4ormore" } },
            new Customer { LoginId = "ford", PricingIds = new List<string> { "5for4classic", "fixedprice3", "3ormore" } },
        };
    }
}