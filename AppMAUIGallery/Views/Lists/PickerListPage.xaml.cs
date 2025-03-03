using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class PickerListPage : ContentPage
{
	public PickerListPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		pickerControl.ItemsSource = MovieList.GetList();
    }

    private void pickerControl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}