using LehaProjectMVC.Core.Entities.Base;

namespace LehaProjectMVC.Core.Entities
{
    public class CartItem : EntityBase
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
