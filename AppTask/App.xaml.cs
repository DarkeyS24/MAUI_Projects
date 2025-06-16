using AppTask.Libraries.Authentications;
using AppTask.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;

namespace AppTask
{
    public partial class App : Application
    {
        private Page page;
        public App(IServiceProvider serviceProvider)
        {
            EntryNoBorder();
            DatePickerNoBorder();
            InitializeComponent();
            if (UserAuth.GetUserLogged() == null)
            {
                page = serviceProvider.GetRequiredService<LoginPage>();
            }
            else if (UserAuth.GetUserLogged() != null)
            {
                page = new NavigationPage(serviceProvider.GetRequiredService<StartPage>());
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(page);
        }

        private void EntryNoBorder()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
                #if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                #elif IOS || MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                #elif WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
                #endif
            });
        }

        private void DatePickerNoBorder()
        {
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
                #if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                #elif IOS
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                #elif WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
                #endif
            });
        }
    }
}