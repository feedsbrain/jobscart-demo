using System;
using System.Collections.Generic;
using System.Linq;
using CryptoHelper;
using JobsCart.Models;

namespace JobsCart.DAL {
    public class DbInitializer {
        internal static void Seed (JobsDbContext context) {

            if (!context.Products.Any ()) {
                // Products
                IList<Product> products = new List<Product> {
                    new Product { Id = "classic", Name = "Classic Ad", Description = "Offers the most basic level of advertisement", Price = 269.99 },
                    new Product { Id = "standout", Name = "Standout Ad", Description = "Allows advertisers to use a company logo and use a longer presentation text", Price = 322.99 },
                    new Product { Id = "premium", Name = "Premium Ad", Description = "Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility", Price = 394.99 }
                };
                context.Products.AddRange (products);
                context.SaveChanges ();
            }

            if (!context.PriceRules.Any ()) {
                // Price Rules
                IList<PriceRule> pricerules = new List<PriceRule> {
                    new PriceRule { Id = "3for2classic", ProductId = "classic", Description = "Gets a 3 for 2 deals on Classic Ads", MinQuantity = 3, BonusQuantity = 1, PriceRuleType = PriceRuleType.BonusWithMinQuantity },
                    new PriceRule { Id = "fixedprice2", ProductId = "standout", Description = "Gets a discount on Standout Ads where the price drops to $299.99 per ad", MinQuantity = 1, DiscountedPrice = 299.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity },
                    new PriceRule { Id = "4ormore", ProductId = "premium", Description = "Gets a discount on Premium Ads where 4 or more are purchased. The price drops to $379.99 per ad", MinQuantity = 4, DiscountedPrice = 379.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity },
                    new PriceRule { Id = "5for4classic", ProductId = "classic", Description = "Gets a 5 for 4 deal on Classic Ads", MinQuantity = 5, BonusQuantity = 1, PriceRuleType = PriceRuleType.BonusWithMinQuantity },
                    new PriceRule { Id = "fixedprice3", ProductId = "standout", Description = "Gets a discount on Standout Ads where the price drops to $309.99 per ad", MinQuantity = 1, DiscountedPrice = 309.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity },
                    new PriceRule { Id = "3ormore", ProductId = "premium", Description = "Gets a discount on Premium Ads when 3 or more are purchased. The price drops to $389.99 per ad", MinQuantity = 3, DiscountedPrice = 389.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity }
                };
                context.PriceRules.AddRange (pricerules);
                context.SaveChanges ();
            }

            if (!context.Customers.Any ()) {
                IList<Customer> customers = new List<Customer> ();

                Customer customer = new Customer {
                    UserName = "unilever",
                    PasswordHash = Crypto.HashPassword ("unilever")
                };
                customer.PriceRules = context.PriceRules.Where (p => p.Id == "3for2classic").ToList();
                customers.Add (customer);

                customer = new Customer {
                    UserName = "apple",
                    PasswordHash = Crypto.HashPassword ("apple")
                };
                customer.PriceRules = context.PriceRules.Where (p => p.Id == "fixedprice2").ToList();
                customers.Add (customer);

                customer = new Customer {
                    UserName = "nike",
                    PasswordHash = Crypto.HashPassword ("nike")
                };
                customer.PriceRules = context.PriceRules.Where (p => p.Id == "4ormore").ToList();
                customers.Add (customer);

                customer = new Customer {
                    UserName = "ford",
                    PasswordHash = Crypto.HashPassword ("ford")
                };
                string[] priceRuleIds = { "5for4classic", "fixedprice3", "3ormore" };
                customer.PriceRules = context.PriceRules.Where (p => priceRuleIds.Contains (p.Id)).ToList();
                customers.Add (customer);

                context.Customers.AddRange (customers);
                context.SaveChanges ();
            }
        }
    }
}