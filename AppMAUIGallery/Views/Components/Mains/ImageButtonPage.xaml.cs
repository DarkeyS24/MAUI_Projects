namespace AppMAUIGallery.Views.Components.Mains;

public partial class ImageButtonPage : ContentPage
{
	bool buttonState = false;
	public ImageButtonPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		buttonState = !buttonState;
		var powerOff = "poweroff.png";
		var powerOn = "poweron.png";
		imageBtn.Source = (buttonState == false) ? ImageSource.FromFile(powerOn) : ImageSource.FromFile(powerOff);

		if (!buttonState)
		{
			this.BackgroundColor = Color.FromArgb("#FFFFFFFF");
			lblState.Text = "ON";
			lblState.TextColor = Color.FromArgb("#FF000000");
		}
		else
		{
            this.BackgroundColor = Color.FromArgb("#FF000000");
            lblState.Text = "OFF";
            lblState.TextColor = Color.FromArgb("#FFFFFFFF");
        }
    }
}