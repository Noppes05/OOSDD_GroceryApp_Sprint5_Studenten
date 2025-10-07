using Grocery.App.ViewModels;

namespace Grocery.App.Views;

// Ensure the base class matches across all partial declarations
public partial class ProductCategoryView : ContentPage
{
    public ProductCategoryView(ProductCategoryViewmodel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}