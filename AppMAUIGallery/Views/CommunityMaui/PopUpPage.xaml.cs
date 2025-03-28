using AppMAUIGallery.Views.CommunityMaui.PopUps;
using CommunityToolkit.Maui.Views;

namespace AppMAUIGallery.Views.CommunityMaui;

public partial class PopUpPage : ContentPage
{
	public PopUpPage()
	{
		InitializeComponent();
	}

    private void OnClickedOpenPopUp(object sender, EventArgs e)
    {
		var popup = new MyPopUp();
		this.ShowPopup(popup);
    }
}