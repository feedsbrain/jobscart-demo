using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobsCart.Models {
    public class Customer : IDataModel {
        [Key]
        public string LoginId { get; set; }
        public IEnumerable<string> PricingIds { get; set; }
        public IEnumerable<Pricing> Pricings { get; set; }
    }
}