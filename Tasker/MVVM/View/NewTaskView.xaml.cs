using MiniProyectos.Tasker.MVVM.ViewModel;
using MiniProyectos.Tasker.MVVM.Model;

namespace MiniProyectos.Tasker.MVVM.View;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}
    private async void AddTaskClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        var selectedCategory =
             vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id
            };
            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else if (selectedCategory == null)
        {
            await DisplayAlert("Selección Invalida", "Tenés que seleccionar una categoria", "Ok");
        } else
        {
            await DisplayAlert("Selección Invalida", "Tenés que nombrar la tarea", "Ok");
        }
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string category =
             await DisplayPromptAsync("Nueva categoría",
             "Escriba el nombre de la nueva categoría",
             maxLength: 15,
             keyboard: Keyboard.Text);

        var r = new Random();

        if (!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(new Category
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(
                      r.Next(0, 255),
                      r.Next(0, 255),
                      r.Next(0, 255)).ToHex(),
                CategoryName = category
            });
        }
    }
}