using LehaProjectMVC.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehaProjectMVC.Core.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        public int ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }
    }
}
