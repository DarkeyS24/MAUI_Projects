namespace AppMAUIGallery.Views.Components.Forms;

public partial class SliderPage : ContentPage
{
	public SliderPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		lblQtd.Text = "Quantidade de quartos: " + e.NewValue.ToString();
		if (e.NewValue >= (slider.Maximum / 2))
		{
			slider.ThumbColor = Color.FromArgb("#FF00FF00");
		}
		else
		{
            slider.ThumbColor = Color.FromArgb("#FFFF0000");
        }
    }

    private void slider_DragCompleted(object sender, EventArgs e)
    {
        lblStatus.Text = "Completou o arrasto!";
    }

    private void slider_DragStarted(object sender, EventArgs e)
    {
        lblStatus.Text = "Iniciou o arrasto!";
    }
}