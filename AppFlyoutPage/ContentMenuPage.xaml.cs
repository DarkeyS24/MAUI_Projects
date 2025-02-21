using System.Collections.ObjectModel;

namespace AppFlyoutPage;

public partial class ContentMenuPage : FlyoutPage
{
    public ContentMenuPage()
	{
		InitializeComponent();
    }
    private void OnButtonClickedPage1(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new Page1());
        IsPresented = false;
    }

    private void OnButtonClickedPage2(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new Page2());
        IsPresented = false;
    }

    private void OnButtonClickedPage3(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new Page3());
        IsPresented = false;
    }
}