using System.Collections.ObjectModel;
using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class CollectionViewPage : ContentPage
{
    private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
    private int countMovies;
	public CollectionViewPage()
	{
		InitializeComponent();
        AddTenMovies();
		collectionViewControl.ItemsSource = movies;
	}

    private async void RefreshView_Refreshing(object sender, EventArgs e)
    {
		RefreshView refreshView = (RefreshView)sender;
		refreshView.IsRefreshing = true;
		await Task.Delay(3000);
        collectionViewControl.ItemsSource = MovieList.GetList();
        refreshView.IsRefreshing = false;
    }

    private void collectionViewControl_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
        AddTenMovies();
    }

    private void AddTenMovies()
    {
        for (int i=0;i<20;i++)
        {
            Movie movie = new Movie
            {
                Id = countMovies++,
                Name = $"Filme {countMovies}",
                Description = $"Descrição {countMovies}",
                Duration = new TimeSpan(2,0,0),
                LaunchYear = 2025
            };
            movies.Add(movie);
        }
    }
}