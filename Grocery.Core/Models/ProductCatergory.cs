using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class ProductCatergory : Model
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public ProductCatergory(int id, string name, int categoryId, int productid) : base(id, name)
        {
            ProductId = productid;
            CategoryId = categoryId;
        }
    }
}
