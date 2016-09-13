using LehaProjectMVC.Core.Entities.Base;
using System.Collections.Generic;

namespace LehaProjectMVC.Core.Entities
{
    public class Cart : EntityBase
    {
        public int UserId { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
