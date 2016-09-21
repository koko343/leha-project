using LehaProjectMVC.Core.Entities;
using LehaProjectMVC.Core.Interfaces.Repositories.Base;
using LehaProjectMVC.Data;
using LehaProjectMVC.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LehaProjectMVC.Services
{
    public class ImageService
    {
        private IRepository<Image> imageRepository;

        public ImageService()
        {
            this.imageRepository = new Repository<Image>(new DataContext());
        }

        public List<Image> GetAll()
        {
            return this.imageRepository.GetAll().ToList<Image>();
        }

        public int CreateImage(HttpPostedFileBase image)
        {
            if (image != null)
            {
                Image img = new Image();
                string GUI = "/Content/img/" + image.FileName;
                
                img.Name = image.FileName;
                img.ImageUrl = GUI;
                image.SaveAs(HttpContext.Current.Server.MapPath(GUI));

                this.imageRepository.Add(img);
                
                this.imageRepository.SaveChanges();

            }
            
            return this.imageRepository.GetAll().ToList<Image>().Last().Id; ;
        }

        public bool DeleteItemById(int id)
        {
            if(id!=0)
            {
                var imageToDelete = this.imageRepository.GetById(id);

                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(imageToDelete.ImageUrl)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(imageToDelete.ImageUrl));
                }

                this.imageRepository.Delete(imageToDelete);
                this.imageRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
