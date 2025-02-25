using AppJogoForca.Libraries.Text;
using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca;

public partial class MainPage : ContentPage
{
	private Word word;
	private int misses = 0;

	public MainPage()
	{
		
		InitializeComponent();

		ResetScreen();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
        button.IsEnabled = false;
		string letter = button.Text;
		var positions =word.Text.AllIndexesOf(letter);

		if(positions.Count == 0)
		{
			misses++;
			imgMain.Source = ImageSource.FromFile($"forca{misses + 1}.png");
			button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Misses"] as Style;

			if (misses == 6)
			{
				await DisplayAlert("You lose!", "Wanna try again?", "New game");
				ResetScreen();
			}
            return;
		}

		foreach(int position in positions)
		{
			lblText.Text = lblText.Text.Remove(position, 1).Insert(position, letter);
            button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Hits"] as Style;
        }
	}

    private void ResetScreen()
    {
		ResetKeyboard();
		ResetMisses();
		GenerateNewWord();
    }
	private void GenerateNewWord()
	{
		var repository = new WordRepository();
        word = repository.GetRamdomWord();

        lblTips.Text = word.Tips;
        lblText.Text = new string('_', word.Text.Length);
	}
	private void ResetMisses()
	{
		misses = 0;
		imgMain.Source = ImageSource.FromFile("forca1.png");
	}
	private void ResetKeyboard()
	{
		ResetVirtualKey((HorizontalStackLayout)keyboardContainer.Children[0]);
		ResetVirtualKey((HorizontalStackLayout)keyboardContainer.Children[1]);
		ResetVirtualKey((HorizontalStackLayout)keyboardContainer.Children[2]);
	}
	private void ResetVirtualKey(HorizontalStackLayout h)
	{
		foreach(Button button in h.Children)
		{
			button.IsEnabled = true;
            button.Style = null;
        }
	}
}