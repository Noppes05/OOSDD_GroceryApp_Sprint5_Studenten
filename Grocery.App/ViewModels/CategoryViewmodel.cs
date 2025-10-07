using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public class CategoryViewmodel : BaseViewModel
    {
        private readonly ICategorySevice _categorySevice;
        public ObservableCollection<Category> Categories { get; set; }
        public CategoryViewmodel(ICategorySevice categorySevice)
        {
            _categorySevice = categorySevice;
            Categories = [];
            foreach (Category c in _categorySevice.getAll()) Categories.Add(c);
        }
    }
}
