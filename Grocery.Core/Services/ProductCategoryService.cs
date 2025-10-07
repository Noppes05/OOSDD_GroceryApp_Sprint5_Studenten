using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
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

        public ProductCategoryService(IProductCategory productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

    }
}
