using CommunityToolkit.Maui.Views;

namespace AppMAUIGallery.Views.CommunityMaui.PopUps;

public partial class MyPopUp : Popup
{
	public MyPopUp()
	{
		InitializeComponent();
	}

    private void OnClickedClose(object sender, EventArgs e)
    {
		this.Close();
    }

    private void OnClickedSaveEmailAndClose(object sender, EventArgs e)
    {
        //Slavar email
        this.Close();   
    }
}