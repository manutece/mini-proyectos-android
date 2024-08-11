using MiniProyectos.MauiWeather.MVVM.ViewModels;

namespace MiniProyectos.MauiWeather.MVVM.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();
	}
}