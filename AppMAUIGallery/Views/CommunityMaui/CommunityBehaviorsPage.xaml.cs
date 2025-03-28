using AppMAUIGallery.Views.CommunityMaui.ViewModels;

namespace AppMAUIGallery.Views.CommunityMaui;

public partial class CommunityBehaviorsPage : ContentPage
{
	public CommunityBehaviorsPage()
	{
		InitializeComponent();
	}

    private void OnPressed(object sender, EventArgs e)
    {
		var vm = (CommunityBehaviorPageViewModel)BindingContext;
		if (vm.PressedCommand.CanExecute(null))
		{
            vm.PressedCommand.Execute(vm);
        }
    }
}