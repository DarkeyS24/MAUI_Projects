namespace AppMAUIGallery.Views.Components.Forms;

public partial class CheckBoxPage : ContentPage
{
	public CheckBoxPage()
	{
		InitializeComponent();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		List<string> stringList = new List<string>();

		CheckBox check = (CheckBox)sender;
		HorizontalStackLayout horizontal = (HorizontalStackLayout)check.Parent;
		VerticalStackLayout vertical = (VerticalStackLayout)horizontal.Parent;
		for(int i = 1; i < 5; i++)
		{
			HorizontalStackLayout stack = (HorizontalStackLayout)vertical.Children[i];
			CheckBox checkBox = (CheckBox)stack.Children[0];
			Label label = (Label)stack.Children[1];
			if (checkBox.IsChecked == true)
			{
				stringList.Add(label.Text);
            }
		}
		lblStatus.Text = string.Empty;
        foreach (string word in stringList)
        {
			lblStatus.Text += word + "\n";
        }
    }
}