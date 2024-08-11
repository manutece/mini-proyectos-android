using MiniProyectos.ProsperDaily.MVVM.ModelViews;

namespace MiniProyectos.ProsperDaily.MVVM.Views;

public partial class TransactionsPage : ContentPage
{
	public TransactionsPage()
	{
		InitializeComponent();
		BindingContext = new TransactionSummary();
	}

    private async void GuardarTx_Clicked(object sender, EventArgs e)
    {
        var currentVM = (TransactionSummary)BindingContext;
        var message = currentVM.SaveTransaction();
        await DisplayAlert("Info", message, "Ok");
        await Navigation.PopToRootAsync();
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}