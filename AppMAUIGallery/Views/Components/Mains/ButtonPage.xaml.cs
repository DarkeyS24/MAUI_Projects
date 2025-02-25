namespace AppMAUIGallery.Views.Components.Mains;

public partial class ButtonPage : ContentPage
{
	public ButtonPage()
	{
		InitializeComponent();
	}

    private void Button_Pressed(object sender, EventArgs e)
    {
        mainBtn.BackgroundColor = Color.FromArgb("#FFF0F8FF");
        lblLog.Text += $"Pressionado no {DateTime.Now}";
    }

    private void Button_Released(object sender, EventArgs e)
    {
        mainBtn.BackgroundColor = Color.FromArgb("#FFFFFF");
        lblLog.Text += $"\nLiberado no {DateTime.Now}\n";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        lblLog.Text += $"\nClicado no {DateTime.Now}";
    }
}