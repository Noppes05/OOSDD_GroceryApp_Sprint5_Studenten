using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository: IProductCategory
    {
        private readonly List<ProductCatergory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = new List<ProductCatergory>
            {
                new ProductCatergory(1, "Zuivel", 1,1),
                new ProductCatergory(2, "Zuivel",1,2),
                new ProductCatergory(3, "brood",2,3),
                new ProductCatergory(3, "Ontbijtgranen",3,4)
            };
            ;
        }
    }
}
