using LehaProjectMVC.Core.Entities;

namespace LehaProjectMVC.Models.Shopping
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }
    }
}