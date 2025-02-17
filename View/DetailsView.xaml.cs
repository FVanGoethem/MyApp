using MyApp.ViewModel;

namespace MyApp.View;

public partial class DetailsView : ContentPage
{
	DetailsViewModel viewModel;
	public DetailsView(DetailsViewModel viewModel)
	{
		this.viewModel = viewModel;
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        BindingContext = null;
        viewModel.RefreshPage();    // Réinitialise la observablecollection
        BindingContext = viewModel;
    }

    private async void MyAnimatedButton_Clicked(object sender, EventArgs e)
    {
        await MyAnimatedButton.ScaleTo(1.1, 100);
        await MyAnimatedButton.ScaleTo(1.0, 100);
    }
}