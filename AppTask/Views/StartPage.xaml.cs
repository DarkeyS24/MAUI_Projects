using System.Threading.Tasks;
using AppTask.Database.Repositories;
using AppTask.Libraries.Authentications;
using AppTask.Models;
using AppTask.Services;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private ITaskModelRepository repository;
    private AddEditTaskPage AddEditTaskPage;
    private IList<TaskModel> _tasks;
    private ITaskService service;

    public StartPage(ITaskModelRepository repository, AddEditTaskPage addEditTaskPage, ITaskService service)
    {
        InitializeComponent();
        this.repository = repository;
        this.service = service;
        _tasks = [];
        LoadData();
        UserEmail.Text = UserAuth.GetUserLogged().Email;
        this.AddEditTaskPage = addEditTaskPage;
    }

    public void LoadData()
    {
        if (repository.GetAllTasks(UserAuth.GetUserLogged().Id) == null || repository.GetAllTasks(UserAuth.GetUserLogged().Id).Count <= 0)
        {
            emptyLlb.IsVisible = true;
            collectionViewTasks.ItemsSource = null;
        }
        else
        {
            _tasks = repository.GetAllTasks(UserAuth.GetUserLogged().Id).Where(t => t.Deleted == default(DateTimeOffset)).ToList();
            collectionViewTasks.ItemsSource = _tasks;
            emptyLlb.IsVisible = _tasks.Count <= 0;
        }
    }
    private void OnButtonClickedToAdd(object sender, EventArgs e)
    {
        AddEditTaskPage = Handler.MauiContext.Services.GetService<AddEditTaskPage>();
        Navigation.PushModalAsync(AddEditTaskPage);
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
            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                await service.DeleteTask(task.Id);
            }
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

        NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
        if (networkAccess == NetworkAccess.Internet)
        {
            service.Update(task);
        }
    }
    private void OnTapToEdit(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;

        AddEditTaskPage = Handler.MauiContext.Services.GetService<AddEditTaskPage>();
        AddEditTaskPage.SetUpdatePage(repository.GetTaskById(task.Id));
        Navigation.PushModalAsync(AddEditTaskPage);
    }
    private void OnTextChanged_FilteredList(object sender, TextChangedEventArgs e)
    {
        var word = e.NewTextValue;
        collectionViewTasks.ItemsSource = _tasks.Where(a => a.Name.ToLower().Contains(word.ToLower()));
    }

    private void OnClickedToLogOut(object sender, EventArgs e)
    {
        UserAuth.UserLogOut();

        var page = Handler.MauiContext.Services.GetService<LoginPage>();
        App.Current.MainPage = page;
    }
}