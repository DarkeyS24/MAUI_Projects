using System.Diagnostics;
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
    private IGroupComponentRepository repository;
 
    public Menu()
	{
		InitializeComponent();
        repository = new GroupComponentRepository();
        menuCollection.ItemsSource = repository.GetGroupComponents();
	}

	private void OnTapComponent(object sender, TappedEventArgs e)
	{
            var component = (Component)e.Parameter;
            if (component.ReplaceMainPage == false)
            {
                if (Application.Current.Windows.Count > 0)
                {
                    var flyoutPage = Application.Current.Windows[0].Page as FlyoutPage;
                    if (flyoutPage != null)
                    {
                        var pageInstance = (Page)Activator.CreateInstance(component.Page);
                        flyoutPage.Detail = new NavigationPage(pageInstance);
                        flyoutPage.IsPresented = false;
                    }
                }
        }
        else
        {
            Application.Current.Windows[0].Page = (Page)Activator.CreateInstance(component.Page);
        }
    }

    private void OnTapInicio(object sender, TappedEventArgs e)
    {
        if (Application.Current.Windows.Count > 0)
        {
            var flyoutPage = Application.Current.Windows[0].Page as FlyoutPage;
            if (flyoutPage != null)
            {
                flyoutPage.Detail = new NavigationPage(new AppMAUIGallery.Views.MainPage());
                flyoutPage.IsPresented = false;
            }
        }
    }
}