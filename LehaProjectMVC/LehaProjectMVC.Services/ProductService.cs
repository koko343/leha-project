using LehaProjectMVC.Core.Entities;
using LehaProjectMVC.Core.Interfaces.Repositories.Base;
using LehaProjectMVC.Data;
using LehaProjectMVC.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

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


    }
}
