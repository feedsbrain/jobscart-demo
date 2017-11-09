using NRules.Fluent.Dsl;
using JobsCart.Models;

namespace JobsCart.Rules
{
    public class CustomerDiscountRule : Rule {
        public override void Define()
        {
            Customer customer = null;
            // IEnumerable<Order> orders = null;

            /*
            When()
                .Match<Customer>(() => customer, c => c.IsPreferred)
                .Query(() => orders, x => x
                    .Match<Order>(
                        o => o.Customer == customer,
                        o => !o.IsDiscounted)
                    .Collect()
                    .Where(c => c.Any()));

            Then()
                .Do(ctx => orders.ToList().ForEach(o => o.ApplyDiscount(10.0)))
                .Do(ctx => orders.ToList().ForEach(ctx.Update));

            */
        }
    }
}