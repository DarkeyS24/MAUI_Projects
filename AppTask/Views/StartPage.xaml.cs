using System.Threading.Tasks;
using AppTask.Database.Repositories;
using AppTask.Models;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private ITaskModelRepository repository;
    private IList<TaskModel> _tasks;
	public StartPage()
	{
		InitializeComponent();
        //Ponto de melhoria -> implementar D.I.
        repository = new TaskModelRepository();
        LoadData();
	}

    public void LoadData()
    {
        //if (repository.GetAllTasks() == null || repository.GetAllTasks().Count <= 0)
        //{
        //    emptyLlb.IsVisible = true;
        //    collectionViewTasks.ItemsSource = null;
        //}
        //else
        //{
        //    _tasks = repository.GetAllTasks();
        //    collectionViewTasks.ItemsSource = _tasks;
        //    emptyLlb.IsVisible = false;
        //}
    }
    private void OnButtonClickedToAdd(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new AddEditTaskPage());
    }
    private void ClickedToEntryFocus(object sender, TappedEventArgs e)
    {
        entrySearch.Focus();
    }
    private async void OnImageClickedToDelete(object sender, TappedEventArgs e)
    {
        TaskModel task = (TaskModel)e.Parameter;
        var confirm = await DisplayAlert("Excluir tarefa", $"Deseja excluir esta tarefa: \n{task.Name}?", "Sim", "Não");
        if (confirm)
        {
            repository.DeleteTask(task);
            LoadData();
        }
    }
    private void OnCheckBoxClickedToComplete(object sender, TappedEventArgs e)
    {

        CheckBox checkBox = ((CheckBox)sender);
        TaskModel task = (TaskModel)e.Parameter;
        if (DeviceInfo.Platform != DevicePlatform.WinUI)
        {
            checkBox.IsChecked = !checkBox.IsChecked;
        }
        task.IsCompleted = checkBox.IsChecked;
        repository.UpdateTask(task);
    }
    private void OnTapToEdit(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        Navigation.PushModalAsync(new AddEditTaskPage(repository.GetTaskById(task.Id)));
    }
    private void OnTextChanged_FilteredList(object sender, TextChangedEventArgs e)
    {
        var word = e.NewTextValue;
        collectionViewTasks.ItemsSource = _tasks.Where(a => a.Name.ToLower().Contains(word.ToLower()));
    }
}