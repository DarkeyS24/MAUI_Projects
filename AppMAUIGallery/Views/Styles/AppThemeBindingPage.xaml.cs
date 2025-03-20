namespace AppMAUIGallery.Views.Styles;

public partial class AppThemeBindingPage : ContentPage
{
	public AppThemeBindingPage()
	{
		InitializeComponent();
		Application.Current.UserAppTheme = AppTheme.Dark;
	}
}