namespace AppContentPage;

public partial class Page3 : ContentPage
{
	public Page3()
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