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
        var num = pickerControl.SelectedIndex;
        Movie movie = (Movie)pickerControl.SelectedItem;
        movieImage.Source = ImageSource.FromFile($"filme{num + 1}.png");
        movieNameLbl.Text = movie.Name;
        descLbl.Text = $"Duração: {movie.Duration}\nAno de lanzamento: {movie.LaunchYear}\n\n{movie.Description}";
    }
}