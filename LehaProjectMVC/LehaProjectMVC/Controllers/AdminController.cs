using System.Web.Mvc;
using LehaProjectMVC.Models.Account;
using System.Web.Security;
using LehaProjectMVC.Services;

namespace LehaProjectMVC.Controllers
{
    public class AdminController : Controller
    {
        private ProductService productService;

        public AdminController()
        {
            this.productService = new ProductService();
        }

        public ActionResult Login()
        {
            LoginViewModel logModel = new LoginViewModel();
            return View(logModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(model.Login == "Admin" && model.Password == "123456")
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);

                return RedirectToAction("AdminPanel");
            }

            return View("Login");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [Authorize]
        public ActionResult AdminPanel()
        {
            return View(this.productService.GetAll());
        }

        [Authorize]
        public ActionResult AddProduct()
        {
            return View();
        }

    }
}