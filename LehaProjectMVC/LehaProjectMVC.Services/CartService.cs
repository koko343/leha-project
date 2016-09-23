using LehaProjectMVC.Core.Entities;
using LehaProjectMVC.Core.Interfaces.Repositories.Base;
using LehaProjectMVC.Data;
using LehaProjectMVC.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using LehaProjectMVC.Services.modelsDTO;
using System;

namespace LehaProjectMVC.Services
{
    public class CartService
    {
        private IRepository<Product> productRepository;
        private IRepository<Cart> cartRepository;
        private DataContext context;

        public CartService()
        {
            this.context = new DataContext();
            this.productRepository = new Repository<Product>(this.context);
            this.cartRepository = new Repository<Cart>(this.context);
        }

        public CartItem NewCartItem(int id, Cart cart)
        {
            if(id!=0)
            {
                var product = this.productRepository.GetById(id);

                CartItem cartItem = null;

                if (product != null)
                {
                    cartItem = new CartItem();
                    cartItem.Product = product;
                    cartItem.ProductId = product.Id;
                    cartItem.CartId = cart.Id;
                   
                }

                return cartItem;
            }

            return null;
        }

        
    }
}
