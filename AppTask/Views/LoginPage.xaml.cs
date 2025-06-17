using AppTask.Database.Repositories;
using AppTask.Libraries.Authentications;
using AppTask.Libraries.NovaPasta;
using AppTask.Models;
using AppTask.Services;

namespace AppTask.Views;

public partial class LoginPage : ContentPage
{
	private IUserSevice _userService;
	private IUserModelRepository _repository;

    public LoginPage(IUserSevice userService, IUserModelRepository repository)
    {
        InitializeComponent();
        _userService = userService;
        _repository = repository;
    }

    private async void OnClickToNextAction(object sender, EventArgs e)
    {
        InitializeNextAction();

        try
        {
            var email = GetEntryEmail();
            if (string.IsNullOrEmpty(email) || !EmailValidate.IsValidEmail(email))
            {
                ShowInvalidEmailMessage();
                return;
            }
            else
            {
                await _userService.GetUser(email);
                GoToStep2();
            }
        }
        catch (HttpRequestException)
        {
            await ShowNetworkErrorAlert();
            txtEmail.IsEnabled = true;

        }
        catch (Exception)
        {
            await ShowUnexpectedErrorAlert();
            txtEmail.IsEnabled = true;
        }
        finally
        {
            AILoading.IsVisible = false;
        }
    }

    private async Task ShowUnexpectedErrorAlert()
    {
        await DisplayAlert("Error", "An unexpected error occurred, please try again.", "OK");
    }

    private async Task ShowNetworkErrorAlert()
    {
        await DisplayAlert("Connection error", "we can't communicate with the server at the moment, try again later.", "OK");
    }

    private void InitializeNextAction()
    {
        AILoading.IsVisible = true;
        txtEmail.IsEnabled = false;
        lblEmailValidationMessage.IsVisible = false;
    }

    private void GoToStep2()
    {
        txtEmail.IsEnabled = false;
        nextBtn.IsVisible = false;
        step2.IsVisible = true;
    }

    private void ShowInvalidEmailMessage()
    {
        AILoading.IsVisible = false;
        txtEmail.IsEnabled = true;
        lblEmailValidationMessage.IsVisible = true;
    }

    private string? GetEntryEmail()
    {
        return txtEmail.Text?.Trim().ToLower();
    }

    private async void OnClickToAccessAction(object sender, EventArgs e)
    {
        InitializeAccessAction();

        try
        {
            var code = txtAccesToken.Text?.Trim();
            if (string.IsNullOrEmpty(code))
            {
                AILoadingAT.IsVisible = false;
                lblTokenValidationMessage.IsVisible = true;
                return;
            }

            var userAPI = await _userService.ValidateAccessToken(new UserModel { Email = GetEntryEmail(), AcccessToken = code });
            if (userAPI == null)
            {
                lblTokenValidationMessage.IsVisible = true;
                return;
            }
            UserAuth.SetUserLogged(userAPI);

            AddOrUpdateUserInDatabase(userAPI);
            var _startPage = Handler.MauiContext.Services.GetService<StartPage>();
            App.Current.MainPage = new NavigationPage(_startPage);
        }
        catch (HttpRequestException)
        {
            await ShowNetworkErrorAlert();
        }
        catch (Exception)
        {
            await ShowUnexpectedErrorAlert();
        }
        finally
        {
            txtAccesToken.IsEnabled = true;
            AILoadingAT.IsVisible = false;
        }
    }

    private void AddOrUpdateUserInDatabase(UserModel userAPI)
    {
        var userDB = _repository.GetUser(userAPI.Email);
        if (userDB == null)
            _repository.AddUser(userAPI);
        else
            _repository.UpdateUser(userAPI);
    }

    private void InitializeAccessAction()
    {
        AILoadingAT.IsVisible = true;
        txtAccesToken.IsEnabled = false;
        lblTokenValidationMessage.IsVisible = false;
    }
}