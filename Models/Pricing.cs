using System;
using System.ComponentModel.DataAnnotations;

namespace JobsCart.Models {
    public class Pricing : IDataModel {
        [Key]
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int MinQuantity { get; set; }
        public int BonusQuantity { get; set; }
        public double Price { get; set; }
    }
}