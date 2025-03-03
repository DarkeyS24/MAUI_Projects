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
        listViewControl.ItemsSource = MovieList.GetList();
    }

    private void listViewControl_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Movie movie = (Movie)e.SelectedItem;
        DisplayAlert("Filme selecionado!", $"O filme selecionado é: {movie.Name}", "OK");
    }
}