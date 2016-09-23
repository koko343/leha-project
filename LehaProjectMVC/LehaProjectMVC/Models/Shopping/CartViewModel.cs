using System.Collections.Generic;
using System;

namespace LehaProjectMVC.Models.Shopping
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartList = new List<CartItemViewModel>();
        }

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public List<CartItemViewModel> CartList { get; set; }

        public decimal Total { get; set; }
    }
}