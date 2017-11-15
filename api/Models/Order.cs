using System;
using System.Linq;
using JobsCart.DAL;

namespace JobsCart.Models {
    public class Order : IDataModel {
        public Order (Customer customer, Product product, int quantity) {
            this.Id = Guid.NewGuid ();
            this.Customer = customer;
            this.Product = product;
            this.Quantity = quantity;
        }

        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public double OriginalPrice {
            get { return Product.Price * Quantity; }
        }

        public double DiscountedPrice {
            get {
                // TODO: Use rule engine to apply discount
                double price = 0;
                /*
                using (var rules = new PriceRulesRepository ()) {
                    var rule = rules.FirstOrDefault (r => r.ProductId == this.Product.Id && this.Customer.PricingIds.Contains (r.Id));

                    if (rule is BonusWithMinQuantityRule) {
                        BonusWithMinQuantityRule bonusRule = (BonusWithMinQuantityRule) rule;
                        if (Quantity >= bonusRule.MinQuantity) {
                            price = OriginalPrice - Product.Price;
                        }
                    }

                    if (rule is DiscountWithMinQuantity) {
                        DiscountWithMinQuantity discountRule = (DiscountWithMinQuantity) rule;
                        if (Quantity >= discountRule.MinQuantity) {
                            price = discountRule.Price * Quantity;
                        }
                    }
                }
                 */
                return price;
            }
        }
    }
}