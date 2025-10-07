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
        public ObservableCollection<ProductCatergory> ProductCategories { get; set; } = [];
        [ObservableProperty]
        private Category category = new(0,"");
        public ProductCategoryViewmodel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
            Load();
        }

        private void Load()
        {
            if (category == null) return;
            ProductCategories.Clear();
            foreach (ProductCatergory pc in _productCategoryService.GetAll(category.Id)) ProductCategories.Add(pc);
        }
        public override void OnAppearing()
        {
            base.OnAppearing();
            ProductCategories = new(_productCategoryService.GetAll(category.Id));
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            ProductCategories.Clear();
        }


    }
}
