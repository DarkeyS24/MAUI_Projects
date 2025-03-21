using Microsoft.Maui.Controls.Platform;

namespace AppMAUIGallery.Views.Animations;

public partial class BasicAnimation : ContentPage
{
	public BasicAnimation()
	{
		InitializeComponent();
        image.FadeTo(1, 1500);
    }

    private async void Aumentar(object sender, EventArgs e)
    {
        await image.ScaleTo(2,2000);
    }
    private async void Diminuir(object sender, EventArgs e)
    {
        await image.ScaleTo(0.5, 2000);
    }
    private async void Normal(object sender, EventArgs e)
    {
        border.Background = Colors.White;
        image.Scale = 1;
        await image.FadeTo(1, 1500);
        image.TranslationX = 0;
        image.TranslationY = 0;
        image.Rotation = 0;
        image.RotationX = 0;
        image.RotationY = 0;
    }
    private async void Mover(object sender, EventArgs e)
    {
        await image.TranslateTo(0,100, 1000, Easing.BounceOut);
        //await image.TranslateTo(-100,-100, 2000);
        //await image.TranslateTo(0,0, 1000);
        //await image.TranslateTo(100,-100, 1000);
        //await image.TranslateTo(-100,100, 2000);
        //await image.TranslateTo(0, 0, 1000);
    }
    private async void Rotacao(object sender, EventArgs e)
    {
        await image.RotateTo(360, 2000);
        await image.RotateXTo(360, 2000);
        await image.RotateYTo(360, 2000);

        //await image.RelRotateTo(360, 2000);
    }
    private async void Transparencia(object sender, EventArgs e)
    {
        await image.FadeTo(0.3, 1000);
    }
    private async void Sequencial(object sender, EventArgs e)
    {
        await image.TranslateTo(100, 0, 250);
        await image.TranslateTo(-100, 0, 500);
        await image.TranslateTo(0, 0, 500);
    }
    private async void Paralelo(object sender, EventArgs e)
    {
        await Task.WhenAll(
            image.TranslateTo(200, 0, 1000),
            image.RotateTo(360, 1000),
            image.FadeTo(0, 1000)
        );
    }
    private void Cancelamento(object sender, EventArgs e)
    {
        image.CancelAnimations();
        Normal(sender, e);
    }
    private void Custom(object sender, EventArgs e)
    {
        var principal = new Animation();
        var animation01 = new Animation(v => image.TranslationX = v, 0, 150, Easing.BounceOut, null);
        var animation02 = new Animation(v => image.Rotation = v, 0, 360, null, null);
        var animation03 = new Animation(v => image.TranslationX = v, 150, 0, Easing.BounceOut, null);
        var animation04 = new Animation(v => image.Rotation = v, 0, -360, null, null);

        principal.Add(0, 0.25, animation01);
        principal.Add(0.25, 0.50, animation02);
        principal.Add(0.50, 0.75, animation03);
        principal.Add(0.75, 1, animation04);

        principal.Commit(this, "AnimacaoPerzonalizada", 16, 10000, null, null, null);
        //animation01.Commit(this, "MoverORobo", 16, 3000, null, null, null);
    }
    private void Cor(object sender, EventArgs e)
    {
        border.ColorTo(Colors.White, Colors.Purple, v => border.BackgroundColor = v, 2000, null);
    }
}