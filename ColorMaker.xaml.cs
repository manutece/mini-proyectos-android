using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
using System;

namespace MiniProyectos;

public partial class ColorMaker : ContentPage
{

    bool EsRandom;
    string HexValue;

    public ColorMaker()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!EsRandom)
        {
            var red = SliderRed.Value;
            var green = SliderGreen.Value;
            var blue = SliderBlue.Value;
            Color color = Color.FromRgb(red, green, blue);
            Debug.WriteLine("Colores: " + red + " " + green + " " + blue);
            SetColor(color);
        }

    }

    private void SetColor(Color color)
    {
        ButtonRandom.BackgroundColor = color;
        Container.BackgroundColor = color;
        HexValue = color.ToHex();
        LabelHex.Text = HexValue;
    }

    private void ButtonRandom_Clicked(object sender, EventArgs e)
    {
        EsRandom = true;
        var random = new Random();
        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        SetColor(color);

        SliderRed.Value = color.Red;
        SliderGreen.Value = color.Green;
        SliderBlue.Value = color.Blue;

        EsRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(HexValue);
        var toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toast.Show();
    }
}