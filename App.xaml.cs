using MiniProyectos.Calculator.MVVM;
using MiniProyectos.MauiWeather.MVVM.Views;
using MiniProyectos.ProsperDaily.MVVM.Models;
using MiniProyectos.ProsperDaily.MVVM.Views;
using MiniProyectos.ProsperDaily.Repositories;
using MiniProyectos.Tasker.MVVM.View;
using System.Diagnostics;

namespace MiniProyectos
{
    public partial class App : Application
    {
        public static BaseRepository<Transaction>
            TransactionsRepo { get; private set; }
        public App(BaseRepository<Transaction> _transactionRepo)
        {
            //InitializeComponent();

            TransactionsRepo = _transactionRepo;

            ////MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainView();

                InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }
    }
}
