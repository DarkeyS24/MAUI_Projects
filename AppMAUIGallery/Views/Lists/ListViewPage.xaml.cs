using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class ListViewPage : ContentPage
{
	public ListViewPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        listViewControl.ItemsSource = MovieList.GetGroupList().Take(2);
        listViewControl.HeightRequest = DeviceDisplay.MainDisplayInfo.Height;
    }

    private void listViewControl_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Movie movie = (Movie)e.SelectedItem;
        DisplayAlert("Filme selecionado!", $"O filme selecionado é: {movie.Name}", "OK");
    }

    private async void listViewControl_Refreshing(object sender, EventArgs e)
    {
        listViewControl.IsRefreshing = true;
        await Task.Delay(3000);
        listViewControl.ItemsSource = MovieList.GetGroupList();
        listViewControl.IsRefreshing = false;
    }
}