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
        private IRepository<CartItem> cartItemRepository;
        private DataContext context;

        public CartService()
        {
            this.context = new DataContext();
            this.productRepository = new Repository<Product>(this.context);
            this.cartRepository = new Repository<Cart>(this.context);
            this.cartItemRepository = new Repository<CartItem>(this.context);
        }

        public int GetId()
        {
            var count = this.cartRepository.GetAll().Count<Cart>();

            if (count == 0)
            {
                return 1;
            }
            else
            {
                return this.cartRepository.GetAll().ToList<Cart>().Last().Id;
            }
        }

        public void CartItemToSave(CartItem cartToSave)
        {
            this.cartItemRepository.Add(cartToSave);
            this.cartItemRepository.SaveChanges();
        }

        public void SaveCart(Cart cartToSave)
        {
            this.cartRepository.Add(cartToSave);
            this.cartRepository.SaveChanges();
        }

        public Cart NewCart()
        {
            var count = this.cartRepository.GetAll().Count<Cart>();
            Cart cart = new Cart();
            cart.DateCreated = DateTime.Now;

            if (count == 0)
            {
                cart.Id = 1;
                
            }else
            {
                cart.Id = this.cartRepository.GetAll().LastOrDefault<Cart>().Id;
            }

            return cart;
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
