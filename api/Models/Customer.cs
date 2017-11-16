using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobsCart.Models {
    public class Customer : IdentityUser, IDataModel {
        public ICollection<PriceRule> PriceRules { get; set; }
    }
}