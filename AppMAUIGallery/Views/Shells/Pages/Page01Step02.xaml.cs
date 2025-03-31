namespace AppMAUIGallery.Views.Shells.Pages;

public partial class Page01Step02 : ContentPage
{
	public Page01Step02()
	{
		InitializeComponent();
	}

    private void GoToRegisterPageStep02(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Register/Step02");
    }

    private void GoToRegisterPageStep01(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("///Step01");
    }
}