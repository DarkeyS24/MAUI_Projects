using Org.Apache.Http.Client;
using Microsoft.Maui.Graphics;
namespace AppMAUIGallery.Views.Components.Mains;


public partial class ButtonPage : ContentPage
{
	public ButtonPage()
	{
		InitializeComponent();
	}

    private void Button_Pressed(object sender, EventArgs e)
    {
        mainBtn.BackgroundColor = new Color.FromArgb("#FF0000");
    }

    private void Button_Released(object sender, EventArgs e)
    {
        mainBtn.BackgroundColor = new Color.FromArgb("#FFFFFF");
    }
}