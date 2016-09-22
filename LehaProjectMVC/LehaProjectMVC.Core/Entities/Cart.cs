using LehaProjectMVC.Core.Entities.Base;
using System.Collections.Generic;

namespace LehaProjectMVC.Core.Entities
{
    public class Cart : EntityBase
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public System.DateTime DateCreated { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
