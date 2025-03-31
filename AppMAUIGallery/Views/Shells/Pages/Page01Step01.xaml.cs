namespace AppMAUIGallery.Views.Shells.Pages;

public partial class Page01Step01 : ContentPage
{
	public Page01Step01()
	{
		InitializeComponent();
	}

    private void GoToStep2(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("Page01Step02");
    }

    private void GoBack(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}