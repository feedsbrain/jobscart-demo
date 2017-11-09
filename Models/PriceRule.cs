namespace JobsCart.Models {
    public enum PriceRuleType {
        BonusWithMinQuantity,
        DiscountWithMinQuantity
    }
    public class PriceRule : IDataModel {
        public string Id { get; set; }
        public PriceRuleType PriceRuleType { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
    }

    public class BonusWithMinQuantityRule : PriceRule {
        public int MinQuantity { get; set; }
        public int BonusQuantity { get; set; }
    }

    public class DiscountWithMinQuantity : PriceRule {
        public int MinQuantity { get; set; }
        public double Price { get; set; }
    }
}