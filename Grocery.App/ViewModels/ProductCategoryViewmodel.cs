using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private readonly IProductService _productService;
        private string searchText = "";
        public ObservableCollection<Product> ProductByCategories { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];
        [ObservableProperty]
        private Category category = new(-1000, "hoerenzooi");

        public ProductCategoryViewmodel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        private void Load()
        {
            LoadProductsByCategory();
            LoadAvailableProducts();
        }
        
        private void LoadProductsByCategory()
        {
            if (Category == null) return;
            ProductByCategories.Clear();
            var productCategories = _productCategoryService.GetAll(Category.Id);
            foreach (var productCategory in productCategories)
                ProductByCategories.Add(productCategory);
        }

        private void LoadAvailableProducts()
        {
            AvailableProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (ProductByCategories.FirstOrDefault(g => g.Id == p.Id) == null && (searchText == "" || p.Name.ToLower().Contains(searchText.ToLower())))
                    AvailableProducts.Add(p);
        }


        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            LoadAvailableProducts();
        }

        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (Category == null || product == null) return;
            _productCategoryService.AddProductToCategory(product, Category);
            Load();
        }

        partial void OnCategoryChanged(Category value)
        {
            Load();
        }

    }
}
