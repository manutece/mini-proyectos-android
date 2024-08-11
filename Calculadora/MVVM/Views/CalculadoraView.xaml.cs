using MiniProyectos.Calculadora.MVVM.ViewModels;
namespace MiniProyectos.Calculadora.MVVM.Views;

public partial class CalculadoraView : ContentPage
{
	public CalculadoraView()
	{
		InitializeComponent();
		//BindingContext = new CalculadoraViewModel();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var viewModel = (CalculadoraViewModel)BindingContext;
		viewModel.Calcular();
    }
}