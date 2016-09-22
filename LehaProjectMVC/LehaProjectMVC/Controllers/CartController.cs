using LehaProjectMVC.Core.Entities;
using LehaProjectMVC.Services;
using System;
using System.Web.Mvc;

namespace LehaProjectMVC.Controllers
{
    public class CartController : Controller
    {
        private CartService cartService;

        public CartController()
        {
            cartService = new CartService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            if(id != 0)
            {
                Cart cart = (Cart)Session["Cart"];

                if (cart == null)
                {
                    cart = new Cart();
                    cart.Id = 1;
                    cart.DateCreated = DateTime.Now;
                    Session["Cart"] = cart;
                }

                var cartItem = this.cartService.NewCartItem(id, 1, cart);
                if(cartItem!=null)
                {
                    cartItem.Id = 1;
                    cart.CartItems.Add(cartItem);
                }
            }

            return RedirectToAction("ItemPage", "Home", new { id = id });
        }
    }
}