using LehaProjectMVC.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace LehaProjectMVC.Core.Entities
{
    public class CartItem : EntityBase
    {
        public int CartId { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
