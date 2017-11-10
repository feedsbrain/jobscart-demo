using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsCart.DAL;
using JobsCart.Models;
using Microsoft.Extensions.DependencyInjection;

namespace JobsCart.DAL {
    public static class SeedData {
        public static async Task SeedAsync (JobsDbContext dbContext) {
            // Products
            IList<Product> products = new List<Product> {
                new Product { Id = "classic", Name = "Classic Ad", Description = "Offers the most basic level of advertisement", Price = 269.99 },
                new Product { Id = "standout", Name = "Standout Ad", Description = "Allows advertisers to use a company logo and use a longer presentation text", Price = 322.99 },
                new Product { Id = "premium", Name = "Premium Ad", Description = "Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility", Price = 394.99 }
            };
            await dbContext.Products.AddRangeAsync (products);

            // Price Rules
            IList<PriceRule> pricerules = new List<PriceRule> {
                new PriceRule { Id = "3for2classic", ProductId = "classic", Description = "Gets a 3 for 2 deals on Classic Ads", MinQuantity = 3, BonusQuantity = 1, PriceRuleType = PriceRuleType.BonusWithMinQuantity },
                new PriceRule { Id = "fixedprice2", ProductId = "standout", Description = "Gets a discount on Standout Ads where the price drops to $299.99 per ad", MinQuantity = 1, DiscountedPrice = 299.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity },
                new PriceRule { Id = "4ormore", ProductId = "premium", Description = "Gets a discount on Premium Ads where 4 or more are purchased. The price drops to $379.99 per ad", MinQuantity = 4, DiscountedPrice = 379.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity },
                new PriceRule { Id = "5for4classic", ProductId = "classic", Description = "Gets a 5 for 4 deal on Classic Ads", MinQuantity = 5, BonusQuantity = 1, PriceRuleType = PriceRuleType.BonusWithMinQuantity },
                new PriceRule { Id = "fixedprice3", ProductId = "standout", Description = "Gets a discount on Standout Ads where the price drops to $309.99 per ad", MinQuantity = 1, DiscountedPrice = 309.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity },
                new PriceRule { Id = "3ormore", ProductId = "premium", Description = "Gets a discount on Premium Ads when 3 or more are purchased. The price drops to $389.99 per ad", MinQuantity = 3, DiscountedPrice = 389.99, PriceRuleType = PriceRuleType.DiscountWithMinQuantity }
            };
            await dbContext.PriceRules.AddRangeAsync (pricerules);

            // Customer
            IList<Customer> customers = new List<Customer> ();

            Customer customer = new Customer {
                LoginId = "unilever"
            };
            customer.PriceRules = dbContext.PriceRules.Where (p => p.Id == "3for2classic");
            customers.Add (customer);

            customer = new Customer {
                LoginId = "apple"
            };
            customer.PriceRules = dbContext.PriceRules.Where (p => p.Id == "fixedprice2");
            customers.Add (customer);

            customer = new Customer {
                LoginId = "nike"
            };
            customer.PriceRules = dbContext.PriceRules.Where (p => p.Id == "4ormore");
            customers.Add (customer);

            customer = new Customer {
                LoginId = "ford"
            };
            string[] priceRuleIds = { "5for4classic", "fixedprice3", "3ormore" };
            customer.PriceRules = dbContext.PriceRules.Where (p => priceRuleIds.Contains (p.Id));
            customers.Add (customer);

            await dbContext.Customers.AddRangeAsync (customers);
        }
    }
}