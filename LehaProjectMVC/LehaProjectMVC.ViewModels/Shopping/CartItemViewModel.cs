using LehaProjectMVC.Core.Entities;

namespace LehaProjectMVC.ViewModels.Shopping
{
    public class CartItemViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}