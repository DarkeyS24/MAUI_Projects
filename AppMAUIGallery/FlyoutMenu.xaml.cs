using AppMAUIGallery.Libraries.Fix;

namespace AppMAUIGallery;

public partial class FlyoutMenu : FlyoutPage
{
	public FlyoutMenu()
	{
		InitializeComponent();
	}

    private void FlyoutPage_IsPresentedChanged(object sender, EventArgs e)
    {
		KeyboardFix.HideKeyboard();
    }
}