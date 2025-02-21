namespace AppContentPage;

public partial class Page2 : ContentPage
{
	public Page2()
	{
		InitializeComponent();
	}

    private void NextPage(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Page3());
    }

    private void PreviousPage(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}