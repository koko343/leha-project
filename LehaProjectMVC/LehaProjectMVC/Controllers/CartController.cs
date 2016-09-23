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
        private ProductService productService;

        public CartController()
        {
            cartService = new CartService();
            productService = new ProductService();
        }

        public ActionResult Index()
        {
            decimal total = 0;
            var itemsInCart = 0;
            CartViewModel cartViewModel = (CartViewModel)Session["Cart"];

            if (cartViewModel != null && cartViewModel.CartList.Count != 0)
            {
                itemsInCart = cartViewModel.CartList.Count;

                foreach (var item in cartViewModel.CartList)
                {
                    total += item.Price;
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
                CartViewModel cart = (CartViewModel)Session["Cart"];
                CartItemViewModel cartItem = null;

                if (cart == null)
                {
                    cart = new CartViewModel();
                    cart.DateCreated = DateTime.Now;
                    cart.Id = this.cartService.GetId();
                    Session["Cart"] = cart;
                }

                var currentProduct = this.productService.GetById(id);
                if (currentProduct != null)
                {
                    cartItem = new CartItemViewModel();
                    cartItem.Description = currentProduct.Description;
                    cartItem.Image = currentProduct.Image;
                    cartItem.Name = currentProduct.Name;
                    cartItem.Price = currentProduct.Price;
                    cartItem.ProductId = currentProduct.Id;
                }

                cart.CartList.Add(cartItem);
            }

            return RedirectToAction("ItemPage", "Home", new { id = id });
        }

        public ActionResult RemoveFromCart(int id)
        {
            if (id != 0)
            {
                CartViewModel cart = (CartViewModel)Session["Cart"];

                if (cart != null)
                {
                    cart.CartList.Remove(cart.CartList.Find(ci => ci.ProductId == id));
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            CartViewModel cart = (CartViewModel)Session["Cart"];

            if(cart!=null && cart.CartList.Count!=0)
            {
                Cart cartToSave = new Cart();
                cartToSave.DateCreated = cart.DateCreated;
                cartToSave.Total = cart.Total;
                this.cartService.SaveCart(cartToSave);

                foreach (var item in cart.CartList)
                {
                    CartItem itemToSave = new CartItem()
                    {
                        ProductId = item.ProductId,
                        CartId = cartToSave.Id
                    };

                    this.cartService.CartItemToSave(itemToSave);
                }

                Session.Clear();
            }

            return RedirectToAction("Index","Home");
        }

    }
}