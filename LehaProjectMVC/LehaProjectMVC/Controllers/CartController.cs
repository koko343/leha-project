using LehaProjectMVC.Core.Entities;
using LehaProjectMVC.Models.Shopping;
using LehaProjectMVC.Services;
using System;
using System.Web.Mvc;

namespace LehaProjectMVC.Controllers
{
    [HandleError]
    public class CartController : Controller
    {
        private CartService cartService;

        public CartController()
        {
            cartService = new CartService();
        }

        public ActionResult Index()
        {
            var itemsInCart = 0;
            CartViewModel cartViewModel = null;
            Cart currentCart = (Cart)Session["Cart"];
            decimal total = 0;

            if (currentCart != null && currentCart.CartItems.Count != 0)
            {
                itemsInCart = currentCart.CartItems.Count;
                cartViewModel = new CartViewModel();
                foreach (var item in currentCart.CartItems)
                {
                    total += item.Product.Price;
                    cartViewModel.Id = item.Id;

                    CartItemViewModel itemViewModel = new CartItemViewModel()
                    {
                        ProductId = item.Product.Id,
                        Description = item.Product.Description,
                        Name = item.Product.Name,
                        Image = item.Product.Image,
                        Price = item.Product.Price,
                    };

                    cartViewModel.CartList.Add(itemViewModel);
                }

                cartViewModel.Total = total;
                ViewBag.ItemsInCart = itemsInCart;
                return View(cartViewModel);
            }

            ViewBag.ItemsInCart = itemsInCart;
            return View("KeepShoppint");
        }

        public ActionResult AddToCart(int id)
        {
            if (id != 0)
            {
                Cart cart = (Cart)Session["Cart"];

                if (cart == null)
                {
                    cart = new Cart();
                    cart.Id = 1;
                    cart.DateCreated = DateTime.Now;
                    Session["Cart"] = cart;
                }

                var cartItem = this.cartService.NewCartItem(id, cart);
                if (cartItem != null)
                {
                    cartItem.Id = 1;
                    cart.CartItems.Add(cartItem);
                }
            }

            return RedirectToAction("ItemPage", "Home", new { id = id, isInCart = true });
        }

        public ActionResult RemoveFromCart(int id)
        {
            if (id != 0)
            {
                Cart cart = (Cart)Session["Cart"];

                if (cart != null)
                {
                    cart.CartItems.Remove(cart.CartItems.Find(ci => ci.ProductId == id));
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}