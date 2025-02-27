namespace AppMAUIGallery.Views.Components.Forms;

public partial class SwitchPage : ContentPage
{
	public SwitchPage()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
		lblStatus.Text = (e.Value == true) ? "On" : "Off";
		lblStatus1.Text = (e.Value == true) ? $"Marcado: {e.Value}" : $"Marcado: {e.Value}";
    }
}