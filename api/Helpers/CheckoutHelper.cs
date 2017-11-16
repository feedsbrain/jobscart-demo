using System.Collections.Generic;
using System.Linq;
using JobsCart.Models;

namespace JobsCart.Helpers
{
    public class Checkout
    {
        private HashSet<PriceRule> _priceRules;
        private Order _order;

        public Checkout(HashSet<PriceRule> priceRules)
        {
            _priceRules = priceRules;
        }

        public void Add(Order order)
        {
            _order = order;
        }

        public double Total()
        {
            var result = _order.TotalPrice;
            foreach (var rule in _priceRules)
            {
                var p = _order.OrderDetails.FirstOrDefault(od => od.Product.Id == rule.ProductId);
                if (p != null)
                {
                    switch (rule.PriceRuleType)
                    {
                        case PriceRuleType.BonusWithMinQuantity:
                            if (p.Quantity >= rule.MinQuantity)
                            {
                                result -= (p.Product.Price * rule.BonusQuantity);
                            }
                            break;
                        case PriceRuleType.DiscountWithMinQuantity:
                            if (p.Quantity >= rule.MinQuantity)
                            {
                                var originalPrice = (p.Product.Price * p.Quantity);
                                var discountedPrice = (rule.DiscountedPrice * p.Quantity);
                                result -= (originalPrice - discountedPrice);
                            }
                            break;
                    }
                }
            }
            return result;
        }
    }
}