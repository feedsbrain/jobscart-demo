using System.ComponentModel.DataAnnotations;

namespace JobsCart.Models
{
    public class Product : IDataModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}