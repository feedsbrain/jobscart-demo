using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace JobsCart.Models
{
    public enum PriceRuleType
    {
        BonusWithMinQuantity,
        DiscountWithMinQuantity
    }
    public class PriceRule : IDataModel
    {
        [Key]
        public string Id { get; set; }
        public PriceRuleType PriceRuleType { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int MinQuantity { get; set; }
        public int BonusQuantity { get; set; }
        public double DiscountedPrice { get; set; }
        public Product Product { get; set; }
    }

}