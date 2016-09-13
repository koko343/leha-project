using LehaProjectMVC.Services;
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

        public ActionResult Index()
        {
            var a = this.productService.GetAll();
            return View();
        }
    }
}