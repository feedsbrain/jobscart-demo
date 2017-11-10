using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobsCart.Models {
    public class Customer : IDataModel {
        [Key]
        public string LoginId { get; set; }
        public IEnumerable<PriceRule> PriceRules { get; set; }
    }
}