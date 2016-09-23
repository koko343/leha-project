using LehaProjectMVC.Services;
using PagedList.Mvc;
using PagedList;
using System.Web.Mvc;
using LehaProjectMVC.Core.Entities;

namespace LehaProjectMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private ProductService productService;

        public HomeController()
        {
            this.productService = new ProductService();
        }

        public ActionResult Index(int? page)
        {
            var products = this.productService.GetAll();

            if (products != null)
            {
                int pageSize = 9;
                int pageNumber = (page ?? 1);
                ViewBag.ActionToGo = "Index";
                ViewBag.ItemsInCart = CartCheck();
                return View(products.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Error");

        }

        public ActionResult OrigPaintings(int? page)
        {
            var products = this.productService.GetAllByType("Original");

            if (products != null)
            {
                int pageSize = 9;
                int pageNumber = (page ?? 1);
                ViewBag.ActionToGo = "OrigPaintings";
                ViewBag.ItemsInCart = CartCheck();
                return View("Index",products.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Error");

        }

        public ActionResult Sale(int? page)
        {
            var products = this.productService.GetAllByType("Sale");

            if (products != null)
            {
                int pageSize = 9;
                int pageNumber = (page ?? 1);
                ViewBag.ActionToGo = "Sale";
                ViewBag.ItemsInCart = CartCheck();
                return View("Index", products.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Error");

        }

        [ChildActionOnly]
        public int CartCheck()
        {
            Cart currentCart = (Cart)Session["Cart"];

            if (currentCart != null && currentCart.CartItems != null)
            {
               return currentCart.CartItems.Count;
            }

            return 0;
        }

        public ActionResult ItemPage(int id)
        {
            ViewBag.IsInCart = false;
            ViewBag.ItemsInCart = 0;

            Cart currentCart = (Cart)Session["Cart"];
            if (currentCart != null && currentCart.CartItems != null)
            {
                ViewBag.ItemsInCart = currentCart.CartItems.Count;

                if (currentCart.CartItems.Find(i => i.ProductId == id) != null)
                {
                    ViewBag.IsInCart = true;
                }
            }
            
            return View(this.productService.GetById(id));
        }


        public ActionResult About()
        {
            ViewBag.ItemsInCart = CartCheck();
            return View();
        }
    }
}