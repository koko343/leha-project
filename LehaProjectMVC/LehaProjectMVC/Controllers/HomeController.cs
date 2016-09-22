using LehaProjectMVC.Services;
using PagedList.Mvc;
using PagedList;
using System.Web.Mvc;
using LehaProjectMVC.Core.Entities;

namespace LehaProjectMVC.Controllers
{
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
                return View("Index", products.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Error");

        }

        public ActionResult ItemPage(int id)
        {
            Cart a = (Cart)Session["Cart"];
            return View(this.productService.GetById(id));
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult SortedItems()
        {
            return View();
        }
    }
}