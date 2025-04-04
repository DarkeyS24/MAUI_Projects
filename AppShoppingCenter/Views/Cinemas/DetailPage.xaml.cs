using CommunityToolkit.Maui.Views;

namespace AppShoppingCenter.Views.Cinemas;

public partial class DetailPage : ContentPage
{
	private bool firstTime = false;
	public DetailPage()
	{
		InitializeComponent();
	}

    private async void PlayPause(object sender, TappedEventArgs e)
    {
		player.IsVisible = true;
		var btn = (Image)sender;
		if (firstTime == false)
		{
            double mediaWidth = player.Width;
            double mediaHeight = player.Height;
            double targetX = 300 - ((mediaWidth / 2) - btn.Width);
            double targetY = 160 - ((mediaHeight / 2) - btn.Height);

            playPauseBtn.IsVisible = false;
            await playPauseBtn.TranslateTo(-targetX, targetY, 500);
            playPauseBtn.IsVisible = true;
            firstTime = true;
		}

		if (player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
		{
			player.Pause();
			playPauseBtn.Source = ImageSource.FromFile("play.png");
			SemanticProperties.SetHint(playPauseBtn, "Botão de Play do trailer");
		}
		else
		{
			player.Play();
			playPauseBtn.Source = ImageSource.FromFile("pause.png");
            SemanticProperties.SetHint(playPauseBtn, "Botão de Pause do trailer");
        }
    }
}