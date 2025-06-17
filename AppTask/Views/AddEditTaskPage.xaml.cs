using System.Threading.Tasks;
using AppTask.Database.Repositories;
using AppTask.Libraries.Authentications;
using AppTask.Models;
using AppTask.Services;

namespace AppTask.Views;

public partial class AddEditTaskPage : ContentPage
{
    private ITaskModelRepository repository;
    private TaskModel _task;
    private ITaskService service;
    public AddEditTaskPage(ITaskModelRepository repository, ITaskService service)
	{
		InitializeComponent();
        _task = new TaskModel();
        this.service = service;
        BindableLayout.SetItemsSource(bindableLayouStep, _task.Sub_Tasks);
        this.repository = repository;
	}
    public void SetUpdatePage(TaskModel task)
	{
        _task = task;
        FillFields();
        BindableLayout.SetItemsSource(bindableLayouStep, _task.Sub_Tasks);
	}

    private void FillFields()
    {
        entry_TaskName.Text = _task.Name;
        editor_TaskDesc.Text = _task.Description;
        datePicker_TaskDate.Date = _task.PrevisionDate.Date;
    }
    private void CloseModal(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void SaveData(object sender, EventArgs e)
    {
        GetDataFromForm();
        if (DataValidation())
        {
            SaveDataOnDatabase();
        }
        Navigation.PopModalAsync();
        UpdateListOnStartPage();  
    }
    private void GetDataFromForm()
    {
        _task.Name = entry_TaskName.Text;
        _task.Description = editor_TaskDesc.Text;
        _task.PrevisionDate = datePicker_TaskDate.Date;
        _task.PrevisionDate = _task.PrevisionDate.AddHours(23);
        _task.PrevisionDate = _task.PrevisionDate.AddMinutes(59);
        _task.PrevisionDate = _task.PrevisionDate.AddSeconds(59);
        _task.IsCompleted = false;
    }
    private bool DataValidation()
    {
        labelTaskName_required.IsVisible = false;
        labelTaskDesc_required.IsVisible = false;

        bool validResult = true;

        if (string.IsNullOrWhiteSpace(_task.Name))
        {
            labelTaskName_required.IsVisible = true;
            validResult = false;
        }

        if (string.IsNullOrWhiteSpace(_task.Description))
        {
            labelTaskDesc_required.IsVisible = true;
            validResult = false;
        }
        return validResult;
    }
    private void SaveDataOnDatabase()
    {
        if (_task.Id == default(Guid))
        {
            _task.Id = Guid.NewGuid();
            _task.UserId = UserAuth.GetUserLogged().Id;
            _task.Created = DateTimeOffset.Now;
            _task.Updated = DateTimeOffset.Now;

            foreach (var step in _task.Sub_Tasks)
            {
                step.Id = Guid.NewGuid();
            }

            repository.AddTask(_task);
            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                try{ 
                    service.Add(_task);
                }catch (Exception ex)
                {
                    DisplayAlert("Error", $"Error saving the task: {ex.Message}", "OK");
                }
            }
        } else
        {
            _task.Updated = DateTimeOffset.Now;
            repository.UpdateTask(_task);
            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess == NetworkAccess.Internet)
            {
                try
                {
                    service.Update(_task);
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", $"Error updating the task: {ex.Message}", "OK");
                }
            }
        }
    }
    private void UpdateListOnStartPage()
    {
        var navPage = (NavigationPage)App.Current.MainPage;
        var startPage = (StartPage)navPage.CurrentPage;
        startPage.LoadData();
    }
    private async void AddStep(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Nova Etapa(Subtarefa)", "Digite o nome da etapa(Subtarefa): ", "Adicionar", "Cancelar");
        if (!string.IsNullOrWhiteSpace(stepName))
        {

            _task.Sub_Tasks.Add(new SubTaskModel { Name = stepName, IsCompleted = false });
        }
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        datePicker_TaskDate.WidthRequest = width - 30;
    }
    private void OnTapToDelete(object sender, TappedEventArgs e)
    {
        _task.Sub_Tasks.Remove((SubTaskModel)e.Parameter);
    }
}