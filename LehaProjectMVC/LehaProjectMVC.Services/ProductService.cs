using LehaProjectMVC.Core.Entities;
using LehaProjectMVC.Core.Interfaces.Repositories.Base;
using LehaProjectMVC.Data;
using LehaProjectMVC.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using LehaProjectMVC.Services.modelsDTO;

namespace LehaProjectMVC.Services
{
    public class ProductService
    {
        private IRepository<Product> productRepository; 

        public ProductService()
        {
            this.productRepository = new Repository<Product>(new DataContext());
        }

        public List<Product> GetAll()
        {
            return this.productRepository.GetAll().ToList<Product>();
        }

        public Product GetById(int id)
        {
            return this.productRepository.GetById(id);
        }

        public List<Product> GetAllByType(string type)
        {
            return this.productRepository.GetAll().Where(x => x.Type == type).ToList<Product>();
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            if(productDTO != null)
            {
                Product product = new Product()
                {
                    Description = productDTO.Description,
                    ImageId = productDTO.ImageId,
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    Type = productDTO.Type
                };

                this.productRepository.Add(product);
                this.productRepository.SaveChanges();
            }
        }

        public bool EditProduct(ProductDTO productDTO)
        {
            if(productDTO != null)
            {
                var productToEdit = this.productRepository.GetById(productDTO.Id);

                productToEdit.Description = productDTO.Description;
                productToEdit.ImageId = productDTO.ImageId;
                productToEdit.Name = productDTO.Name;
                productToEdit.Price = productDTO.Price;
                productToEdit.Type = productDTO.Type;

                this.productRepository.SaveChanges();
                return true;
            }

            return false;
        }

        public void DeleteProduct(int id)
        {
            this.productRepository.Delete(this.productRepository.GetById(id));
            this.productRepository.SaveChanges();
        }

    }
}
