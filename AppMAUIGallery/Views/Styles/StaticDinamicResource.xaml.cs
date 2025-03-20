namespace AppMAUIGallery.Views.Styles;

public partial class StaticDinamicResource : ContentPage
{
	public StaticDinamicResource()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Resources["TitleColor"] = Colors.Green;
    }
}