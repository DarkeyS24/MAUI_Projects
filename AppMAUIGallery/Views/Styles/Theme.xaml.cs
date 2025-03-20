using AppMAUIGallery.Resources.Styles;

namespace AppMAUIGallery.Views.Styles;

public partial class Theme : ContentPage
{
	private bool light = true;
	public Theme()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		ICollection<ResourceDictionary> dictionaries = Application.Current.Resources.MergedDictionaries;

		if (dictionaries != null)
		{
			dictionaries.Remove(dictionaries.ElementAt(2));
			if (light)
			{
				light = !light;
				dictionaries.Add(new DarkTheme());
			}
			else
			{
                light = !light;
                dictionaries.Add(new LightTheme());
            }
        }
    }
}