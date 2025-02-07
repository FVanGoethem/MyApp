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
}