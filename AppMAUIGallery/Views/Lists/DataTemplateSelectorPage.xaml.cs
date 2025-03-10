#if ANDROID
using Android.Graphics;
#endif
using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class DataTemplateSelectorPage : ContentPage
{
	public DataTemplateSelectorPage()
	{
		InitializeComponent();
        collectionViewControl.ItemsSource = MovieList.GetList();
		scroll.HeightRequest = DeviceDisplay.MainDisplayInfo.Height / 2;
	}
}