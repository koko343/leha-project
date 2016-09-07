using LehaProjectMVC.Core.Entities.Base;
using System.Collections.Generic;

namespace LehaProjectMVC.Core.Entities
{
    public class Cart : EntityBase
    {
        public virtual List<CartItem> CartItems { get; set; }
    }
}
