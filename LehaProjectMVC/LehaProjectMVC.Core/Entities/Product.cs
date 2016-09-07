using LehaProjectMVC.Core.Entities.Base;

namespace LehaProjectMVC.Core.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string ImgUrl { get; set; }
    }
}
