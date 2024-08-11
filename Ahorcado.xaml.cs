using PropertyChanged;
using System.ComponentModel;
using System.Diagnostics;

namespace MiniProyectos;
[AddINotifyPropertyChangedInterface]
public partial class Ahorcado : ContentPage, INotifyPropertyChanged
{
    #region UI Propiedades
    public string LetrasAdivinadas
    {
        get => letrasAdivinadas;
        set
        {
            letrasAdivinadas = value;
            OnPropertyChanged();
        }
    }
    public string LetrasElegidasView
    {
        get => letrasElegidasView;
        set
        {
            letrasElegidasView = value;
            OnPropertyChanged();
        }
    }

    public List<char> Abecedario
    {
        get => abecedario; 
        set
        {
            abecedario = value;
            OnPropertyChanged();
        }
    }

    public string Mensaje
    {
        get => mensaje; set
        {
            mensaje = value;
            OnPropertyChanged();
        }
    }
    public string GameStatus
    {
        get => gameStatus; set
        {
            gameStatus = value;
            OnPropertyChanged();
        }
    }
    public string ImagenEstado
    {
        get => imagenEstado; set
        {
            imagenEstado = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Fields
    List<string> words = new List<string>()
        {
            "python",
            "java",
            "maui",
            "dotnet",
            "html",
            "css",
            "react",
            "redux",
            "swift",
            "kotlin",
            "golang",
            "docker",
            "blazor",
            "nodejs",
            "mysql",
            "sqlite",
            "oracle",
            "xamarin",
            "angular"
        };
    string answer = "";
    private string letrasAdivinadas;
    private string letrasElegidasView = "";
    List<char> letrasElegidas = new List<char>();
    private List<char> abecedario = new List<char>();
    private string mensaje;
    private int errores = 0;
    int erroresMax = 6;
    private string gameStatus;
    private string imagenEstado = "ahoracado0.jpg";
    #endregion


    public Ahorcado()
	{
		InitializeComponent();
        Abecedario.AddRange("abcdefghijklmnñopqrstuvwxyz");
        BindingContext = this;
        ElegirPalabra();
        CalcularPalabra(answer, letrasElegidas);
        ImagenEstado = $"ahorcado{errores}.jpg";
    }

    #region GameEngine
    private void ElegirPalabra()
    {
        answer = words[new Random().Next(0, words.Count)];
    }

    private void CalcularPalabra(string answer, List<char> guessed)
    {
        var temp = answer.Select(x => (guessed.IndexOf(x) >= 0 ? x : '_')).ToArray();
        LetrasAdivinadas = string.Join(' ', temp);
    }
    #endregion

    private void Button_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            var letra = btn.Text;
            btn.IsEnabled = false;
            AdivinarLetra(letra[0]);
        }
    }

    private void UpdateStatus()
    {
        GameStatus = $"Errores: {errores} de {erroresMax}.";
    }

    private void AdivinarLetra(char letra)
    {
       if(letrasElegidas.IndexOf(letra) == -1)
        {
            letrasElegidas.Add(letra);
            letrasElegidasView += letra;
        }

        if (answer.IndexOf(letra) >= 0)
        {
            CalcularPalabra(answer, letrasElegidas);
            VerificarGanador();
        }
       else if (answer.IndexOf(letra) == -1)
        {
            
            errores++;
            VerificarPerdedor();
            UpdateStatus();
            ImagenEstado = $"ahorcado{errores}.jpg";
            
        }
        
    }

    private void VerificarPerdedor()
    {
        if (errores == erroresMax)
        {
            Mensaje = "Perdiste!!";
            DeshabilitarLetras();
        }
    }

    private void DeshabilitarLetras()
    {
        foreach (var hijo in BotonesLetras.Children)
        {
            var boton = hijo as Button;
            if (boton != null)
            {
                boton.IsEnabled = false;
            }
        }
    }

    private void HabilitarLetras()
    {
        foreach (var hijo in BotonesLetras.Children)
        {
            var boton = hijo as Button;
            if (boton != null)
            {
                boton.IsEnabled = true;
            }
        }
    }

    private void VerificarGanador()
    {
        if(letrasAdivinadas.Replace(" ","") == answer)
        {
            Mensaje = "Ganaste!!";
            DeshabilitarLetras();
        }
    }

    private void Reset_Clicked(object sender, EventArgs e)
    {
        errores = 0;
        letrasElegidas = new List<char>();
        letrasElegidasView = "";
        ImagenEstado = "ahorcado0.jpg";
        ElegirPalabra();
        CalcularPalabra(answer, letrasElegidas);
        Mensaje = "";
        UpdateStatus();
        HabilitarLetras();
    }
}