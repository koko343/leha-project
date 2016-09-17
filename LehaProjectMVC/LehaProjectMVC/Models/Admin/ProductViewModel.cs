using LehaProjectMVC.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LehaProjectMVC.Models.Admin
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public TypeEnum Type { get; set; }

        public int ImageId { get; set; }

        public IEnumerable<SelectListItem> GetTypeItems()
        {
            yield return new SelectListItem { Text = "All", Value = "All" };
            yield return new SelectListItem { Text = "Original", Value = "Original" };
            yield return new SelectListItem { Text = "Sale", Value = "Sale" };
        }
    }
}