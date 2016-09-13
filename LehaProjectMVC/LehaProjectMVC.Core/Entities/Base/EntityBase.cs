using System.ComponentModel.DataAnnotations;

namespace LehaProjectMVC.Core.Entities.Base
{
    public class EntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
