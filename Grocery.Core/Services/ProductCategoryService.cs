using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategory _productCategoryService;
        private readonly IProductService _productService;

        public ProductCategoryService(IProductCategory productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        public List<Product> GetAll(int id)
        {
            var result = _productCategoryService.GetAll(id);
            List<Product> products = new List<Models.Product>();
            foreach (ProductCatergory item in result)
            {
                Product product = _productService.Get(item.ProductId);
                if(product != null)
                    products.Add(product);
            }
            return products;
        }
    }
}
