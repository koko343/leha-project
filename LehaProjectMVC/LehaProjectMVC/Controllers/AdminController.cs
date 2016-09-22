using System.Web.Mvc;
using LehaProjectMVC.Models.Admin;
using System.Web.Security;
using LehaProjectMVC.Services;
using System.Web;
using LehaProjectMVC.Services.modelsDTO;
using LehaProjectMVC.Core.Enums;

namespace LehaProjectMVC.Controllers
{
    public class AdminController : Controller
    {
        private ProductService productService;
        private ImageService imageService;

        public AdminController()
        {
            this.productService = new ProductService();
            this.imageService = new ImageService();
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
            return View(new ProductViewModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model, HttpPostedFileBase image)
        {
            if(model != null && image != null)
            {

                ProductDTO productDTO = new ProductDTO();
                productDTO.Description = model.Description;
                productDTO.Name = model.Name;
                productDTO.Price = model.Price;
                productDTO.Type = model.Type.ToString();
                productDTO.ImageId = this.imageService.CreateImage(image);


                this.productService.CreateProduct(productDTO);

                return RedirectToAction("AdminPanel");
            }

            return View();
        }

        [Authorize]
        public ActionResult EditItem(int id)
        {
            var product = this.productService.GetById(id);

            ProductViewModel model = new ProductViewModel();
            model.Id = product.Id;
            model.Description = product.Description;
            model.Name = product.Name;
            model.Price = product.Price;
            model.ImageId = product.ImageId;
            if(product.Type == TypeEnum.Original.ToString())
            {
                model.Type = TypeEnum.Original;
            }else if(product.Type == TypeEnum.Sale.ToString())
            {
                model.Type = TypeEnum.Sale;
            }
            else
            {
                model.Type = TypeEnum.All;
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditItem(ProductViewModel model)
        {
            if (model != null)
            {
                ProductDTO productDTO = new ProductDTO();
                productDTO.Id = model.Id;
                productDTO.Description = model.Description;
                productDTO.Name = model.Name;
                productDTO.Price = model.Price;
                productDTO.ImageId = model.ImageId;
                productDTO.Type = model.Type.ToString();


                this.productService.EditProduct(productDTO);
                return RedirectToAction("AdminPanel");
            }

            return View();
        }

        [Authorize]
        public ActionResult DeleteItem(int id)
        {
            if(this.imageService.DeleteItemById(this.productService.GetById(id).ImageId))
            {
                return RedirectToAction("AdminPanel");
            }

            return null;
        }

    }
}