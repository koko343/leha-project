using LehaProjectMVC.Services;
using PagedList.Mvc;
using PagedList;
using System.Web.Mvc;

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

                return View(products.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Error");

        }

        [HttpPost]
        public ActionResult Index(int? page, int id)
        {
            return View();
        }

        public ActionResult ItemPage(int id)
        {
            return View(this.productService.GetById(id));
        }


            public ActionResult About()
        {
            return View();
        }
    }
}