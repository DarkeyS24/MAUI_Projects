namespace AppMAUIGallery.Views.Utils;

public partial class PlatformIdiomPage : ContentPage
{
	public PlatformIdiomPage()
	{
		InitializeComponent();

		#if WINDOWS
			DisplayAlert("Condições de compilação", "Esta mensagem é executada usando condições de compilação", "OK");
		#endif

        if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
		{
			DisplayAlert("Windows", "Esta mensagem é exclusiva do Windows", "OK");
		}

		if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
		{
            DisplayAlert("Desktop", "Esta mensagem é exclusiva para Desktop/PC", "OK");
        }
	}
}