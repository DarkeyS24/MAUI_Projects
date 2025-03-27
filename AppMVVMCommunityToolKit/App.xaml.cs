using AppMVVMCommunityToolKit.Views;

namespace AppMVVMCommunityToolKit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }
    }
}
