namespace AppMAUIGallery.Views.Components.Forms;

public partial class PickerPage : ContentPage
{
	public PickerPage()
	{
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var component = ((Picker)sender);
		string brandName = (string)component.SelectedItem;

		//component.SelectedIndex = 3;
		//component.SelectedItem = component.ItemsSource[0];

		lblItem.Text = "Item selecionado: " + brandName;
    }
}