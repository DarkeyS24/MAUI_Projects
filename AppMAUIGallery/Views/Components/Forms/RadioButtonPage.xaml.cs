namespace AppMAUIGallery.Views.Components.Forms;

public partial class RadioButtonPage : ContentPage
{
	public RadioButtonPage()
	{
		InitializeComponent();
	}

    private void CheckedChangedQ1(object sender, CheckedChangedEventArgs e)
    {
		if (e.Value == true)
		{
			var value = ((RadioButton)sender).Content;
			var color = ((RadioButton)sender).BorderColor;
            lblAnswerQ1.Text = value.ToString();
			borderQ1.Stroke = color;
			borderQ1.Shadow.Brush = color;
            borderQ1.IsVisible = true;
		}
    }

    private void CheckedChangedQ2(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value == true)
        {
            var value = ((RadioButton)sender).Content;
            var color = ((RadioButton)sender).BorderColor;
            lblAnswerQ2.Text = value.ToString();
            borderQ2.Stroke = color;
            borderQ2.Shadow.Brush = color;
            borderQ2.IsVisible = true;
        }
    }
}