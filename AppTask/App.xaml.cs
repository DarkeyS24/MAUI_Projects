using AppTask.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;

namespace AppTask
{
    public partial class App : Application
    {
        public App()
        {
            EntryNoBorder();
            DatePickerNoBorder();
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new LoginPage());
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