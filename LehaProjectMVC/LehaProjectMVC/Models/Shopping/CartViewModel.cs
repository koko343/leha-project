using System.Collections.Generic;
using LehaProjectMVC.Core.Entities;
using System.Linq;

namespace LehaProjectMVC.Models.Shopping
{
    public class CartViewModel
    {
        private List<CartItemViewModel> itemCollection = new List<CartItemViewModel>();

        public void AddItem(Product product, int quantity)
        {
            CartItemViewModel item = itemCollection
              .Where(p => p.Product.Id == product.Id)
              .FirstOrDefault();

            if (item == null)
            {
                itemCollection.Add(new CartItemViewModel
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            itemCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return itemCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            itemCollection.Clear();
        }

        public IEnumerable<CartItemViewModel> Lines
        {
            get { return itemCollection; }
        }
    }
}