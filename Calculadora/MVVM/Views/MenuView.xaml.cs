using MiniProyectos.Calculadora.MVVM.ViewModels;

namespace MiniProyectos.Calculadora.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var element = (Grid)sender;
		var option = ((Label)element.Children.LastOrDefault()).Text;
		var paginaNueva = new CalculadoraView
		{
			BindingContext = new CalculadoraViewModel(option)
		};
		Navigation.PushAsync( paginaNueva );

    }
}