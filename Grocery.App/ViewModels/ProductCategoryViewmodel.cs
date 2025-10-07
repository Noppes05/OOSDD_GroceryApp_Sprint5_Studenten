using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
   [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoryViewmodel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<Product> ProductByCategories { get; set; } = [];
        [ObservableProperty]
        private Category category = new(-1000, "hoerenzooi");

        public ProductCategoryViewmodel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        private void Load()
        {
            if (Category == null) return;
            ProductByCategories.Clear();
            var productCategories = _productCategoryService.GetAll(Category.Id);
            foreach (var productCategory in productCategories)
                ProductByCategories.Add(productCategory);
        }
       
        partial void OnCategoryChanged(Category value)
        {
            Load();
        }

    }
}
