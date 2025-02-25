using System.Diagnostics;
using AppMAUIGallery.Models;
using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
		var categories = new CategoryRepository().GetCategories();

		foreach (var category in categories)
		{
            var lblCategory = new Label();
            lblCategory.Text = category.Name;
			lblCategory.FontFamily = "OpenSansSemibold";
            lblCategory.Margin = new Thickness(0,30,0,0);

			MenuContainer.Children.Add(lblCategory);

			foreach (var component in category.Components)
			{
				var tap = new TapGestureRecognizer();
				tap.CommandParameter = component.Page;
				tap.Tapped += OnTapComponent;

				var lblComponentTitle = new Label();
				lblComponentTitle.FontFamily = "OpenSansSemibold";
                lblComponentTitle.Text = component.Name;
                lblComponentTitle.Margin = new Thickness(10, 10, 0, 0);
				lblComponentTitle.GestureRecognizers.Add(tap);

                var lblComponentDescription = new Label();
				lblComponentDescription.Text = component.Description;
                lblComponentDescription.Margin = new Thickness(10, 5, 0, 0);
                lblComponentDescription.GestureRecognizers.Add(tap);

                MenuContainer.Children.Add(lblComponentTitle);
				MenuContainer.Children.Add(lblComponentDescription);
			}
        }
	}

	private void OnTapComponent(object sender, EventArgs e)
	{
        if (sender is Label label && label.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer tap)
        {
            var page = tap.CommandParameter as Type;
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
            else
            {
                Debug.WriteLine("Erro: O CommandParameter não é uma Page válida.");
            }
        }else
        {
            Debug.WriteLine("Erro: O CommandParameter não é um tipo válido.");
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