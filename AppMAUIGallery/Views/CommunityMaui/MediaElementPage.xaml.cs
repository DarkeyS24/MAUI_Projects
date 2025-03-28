namespace AppMAUIGallery.Views.CommunityMaui;

public partial class MediaElementPage : ContentPage
{
	public MediaElementPage()
	{
		InitializeComponent();
	}

    private void OnClickedToPlay(object sender, EventArgs e)
    {
        if (player.CurrentState != CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            player.Play();
        }
    }

    private void OnClickedToPause(object sender, EventArgs e)
    {
        if (player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            player.Pause();
        }
    }
}