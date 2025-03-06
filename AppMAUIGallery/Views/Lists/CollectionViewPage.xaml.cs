using System.Collections.ObjectModel;
using System.Text;
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
		collectionViewControl.ItemsSource = MovieList.GetGroupList();
	}

    private async void RefreshView_Refreshing(object sender, EventArgs e)
    {
		RefreshView refreshView = (RefreshView)sender;
		refreshView.IsRefreshing = true;
		await Task.Delay(3000);
        collectionViewControl.ItemsSource = MovieList.GetGroupList();
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

    //private void CollectionViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    foreach(Movie movie in e.CurrentSelection)
    //    {
    //        sb.Append(movie.Name + "; ");
    //    }
    //    moviesLbl.Text = sb.ToString();
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {
        collectionViewControl.ScrollTo(4, Position: ScrollToPosition.Center);
    }
}