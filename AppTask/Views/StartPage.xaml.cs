using System.Threading.Tasks;
using AppTask.Database.Repositories;
using AppTask.Libraries.Authentications;
using AppTask.Libraries.Synchronizations;
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
                try
                {
                    await service.DeleteTask(task.Id);
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", $"Error during delete of the task: {ex.Message}", "OK");
                }
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
        task.Updated = DateTimeOffset.Now;
        repository.UpdateTask(task);

        NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
        if (networkAccess == NetworkAccess.Internet)
        {
            try
            {
                service.Update(task);

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Error updating the task: {ex.Message}", "OK");
            }
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

    private async void OnButtonClickedToSync(object sender, EventArgs e)
    {
        try {
        var userId = UserAuth.GetUserLogged().Id;
        var date = SyncData.GetLastSyncDate(); // This will retrieve the last sync date, if any.
        List<TaskModel> localTasks = (date is null)? repository.GetAllTasks(userId).ToList() : repository.GetAllTasks(userId).Where(a => a.Updated >= date).ToList();

        var serverTasks = await service.BatchPush(userId, localTasks); // This will push the local tasks to the server and retrieve the updated list of tasks from the server.

        LocalDatabaseSynchronization(serverTasks); // This will synchronize the local database with the server data.

        SyncData.SetLastSyncDate(DateTimeOffset.Now); // This will set the last sync date to now, indicating that a sync has occurred.

        LoadData(); // Refresh the task list on the UI after synchronization.
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Error during synchronization: {ex.Message}", "OK");
        }
    }

    private void LocalDatabaseSynchronization(List<TaskModel> serverTasks)
    {
        var userId = UserAuth.GetUserLogged().Id;
        var localTasks = repository.GetAllTasks(userId);

        var tasksToLocalAdd = new List<TaskModel>();
        var tasksToLocalUpdate = new List<TaskModel>();

        foreach ( var serverTask in serverTasks)
        {
            var task = localTasks.FirstOrDefault(a => a.Id == serverTask.Id);
            if(task == null)
            {
                tasksToLocalAdd.Add(serverTask);
            }
            else
            {
                if (task.Updated < serverTask.Updated)
                {
                    tasksToLocalUpdate.Add(serverTask);
                }
            }
        }

        repository.AddTasks(tasksToLocalAdd);
        repository.UpdateTasks(tasksToLocalUpdate);
    }
}