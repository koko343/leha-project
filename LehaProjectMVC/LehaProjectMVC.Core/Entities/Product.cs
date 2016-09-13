using LehaProjectMVC.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace LehaProjectMVC.Core.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        public string ImgUrl { get; set; }
    }
}
