using LehaProjectMVC.Core.Entities.Base;
using System.Collections.Generic;

namespace LehaProjectMVC.Core.Entities
{
    public class Image : EntityBase
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
