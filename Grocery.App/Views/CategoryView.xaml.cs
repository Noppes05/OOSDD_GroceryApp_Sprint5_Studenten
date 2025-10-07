using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class CategoryView : ContentPage
{
    public CategoryView(CategoryViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
    }
}