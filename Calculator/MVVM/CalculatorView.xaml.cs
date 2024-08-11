using MiniProyectos.Calculator.MVVM.ViewModels;
namespace MiniProyectos.Calculator.MVVM;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
		BindingContext = new CalculatorViewModel();
	}
}