using CommunityToolkit.Mvvm.Input;
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
    public partial class CategoryViewmodel : BaseViewModel
    {
        private readonly ICategoryService _categorySevice;
        public ObservableCollection<Category> Categories { get; set; }
        public CategoryViewmodel(ICategoryService categorySevice)
        {
            _categorySevice = categorySevice;
            Categories = [];
            foreach (Category c in _categorySevice.getAll()) Categories.Add(c);
        }

        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            Dictionary<string, object> paramater = new() { { nameof(Category), category } };
            await Shell.Current.GoToAsync($"{nameof(Views.ProductCategoryView)}?Titel={category.Name}", true, paramater);
        }

        public void onappearing()
        {
            Categories = new(_categorySevice.getAll());
        }
        public void ondisappearing()
        {
            Categories.Clear();
        }
    }
}
