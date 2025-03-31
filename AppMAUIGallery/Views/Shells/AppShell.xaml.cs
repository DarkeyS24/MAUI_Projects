using AppMAUIGallery.Views.Shells.Pages;

namespace AppMAUIGallery.Views.Shells;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("Page01/Page01Step01", typeof(Page01Step01));
		Routing.RegisterRoute("Page01/Page01Step02", typeof(Page01Step02));
		Routing.RegisterRoute("Page02/Page02Step01", typeof(Page02Step01WithParameters));
	}

    private void BackToGallery(object sender, EventArgs e)
    {
		App.Current.MainPage = new FlyoutMenu();
    }
}