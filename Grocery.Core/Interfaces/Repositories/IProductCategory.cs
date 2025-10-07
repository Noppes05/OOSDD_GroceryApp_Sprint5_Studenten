using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategory
    {
        public List<Models.ProductCatergory> GetAll(int id);

    }
}
