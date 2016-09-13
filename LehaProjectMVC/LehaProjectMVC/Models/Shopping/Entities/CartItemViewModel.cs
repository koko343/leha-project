using LehaProjectMVC.Core.Entities;

namespace LehaProjectMVC.Models.Shopping.Entities
{
    public class CartItemViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}