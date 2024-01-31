namespace ListViewNestedBinding;

using ListViewNestedBinding.ViewModels;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        BindingContext = new MainViewModel();
        InitializeComponent();
    }
}
