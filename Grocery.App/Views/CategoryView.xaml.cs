using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class CategoryView : ContentPage
{
    public CategoryView(CategoryViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoryViewmodel bindingContext)
        {
            bindingContext.OnAppearing();

        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is CategoryViewmodel bindingContext)
        {
            bindingContext.OnDisappearing();
        }
    }
}