using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public List<Models.Product> GetAll(int id);
        public void AddProductToCategory(Product product, Category category);
    }
}
