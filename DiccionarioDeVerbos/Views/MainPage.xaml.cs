using DiccionarioDeVerbos.ViewModels;

namespace DiccionarioDeVerbos.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}