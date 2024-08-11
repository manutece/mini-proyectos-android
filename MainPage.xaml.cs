
using CommunityToolkit.Maui.Alerts;
using MiniProyectos.MauiWeather.MVVM.Views;
using MiniProyectos.ProsperDaily.MVVM.Views;
using System.ComponentModel;
using System.Diagnostics;

namespace MiniProyectos
{
    public partial class MainPage : ContentPage
    { 
        public MainPage()
        {
            InitializeComponent();
        }

        private void colorMaker_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ColorMaker());
        }

        private void ahorcado_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ahorcado());
        }

        private void calculadora_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CalcViewHandler());
        }

        private void MauiWeather_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WeatherView());
        }

        private void ProsperDaily_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppContainer());
        }
    }

}
