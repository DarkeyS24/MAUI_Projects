using System.Collections.ObjectModel;
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class MainPage : ContentPage
{
    private IGroupComponentRepository repository;
    private List<Component> fullList;
    private ObservableCollection<Component> filteredList;

	public MainPage()
	{
		InitializeComponent();
        repository = new GroupComponentRepository();
        fullList = repository.GetComponents();
        filteredList = new ObservableCollection<Component>(fullList);
        componentCollection.ItemsSource = filteredList;
	}

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        var page = (Type)e.Parameter;
        if (page != null)
        {
            if (Application.Current.Windows.Count > 0)
            {
                var flyoutPage = Application.Current.Windows[0].Page as FlyoutPage;
                if (flyoutPage != null)
                {
                    var pageInstance = (Page)Activator.CreateInstance(page);
                    flyoutPage.Detail = new NavigationPage(pageInstance);
                    flyoutPage.IsPresented = false;
                }
            }
        }
    }
    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var word = e.NewTextValue;
        Clear();
        Search(word);
    }
    private void Clear()
    {
        var limit = filteredList.Count;
        for (int i = 0; i < limit; i++)
        {
            filteredList.RemoveAt(0);
        }
    }
    private void Search(string word)
    {
        var _filteredList = fullList.Where(a => a.Name.ToLower().Contains(word.ToLower())).ToList();
        foreach (var item in _filteredList)
        {
            filteredList.Add(item);
        }
    }
}