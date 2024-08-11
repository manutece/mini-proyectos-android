using MiniProyectos.Tasker.MVVM.ViewModel;
using System.Diagnostics;

namespace MiniProyectos.Tasker.MVVM.View;

public partial class MainView : ContentPage
{
	private MainViewModel mainViewModel = new MainViewModel();
	public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
    }
    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = mainViewModel.Tasks,
                Categories = mainViewModel.Categories,
            }
        };
        taskView.

        Navigation.PushAsync(taskView);
    }
}