namespace MyApp.View;

public partial class MainView : ContentPage
{
	MainViewModel viewModel;
	public MainView(MainViewModel viewModel)
	{
		this.viewModel = viewModel;
		InitializeComponent();
		BindingContext=viewModel;
	}
	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		BindingContext = null;
		viewModel.RefreshPage();    // Réinitialise la observablecollection
		BindingContext = viewModel;
	}
}