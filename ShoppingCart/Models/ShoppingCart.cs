using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class ShoppingCartClass
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int numItems { get; set; }
        public double cost { get; set; }
    }
}
