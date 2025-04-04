using AppShoppingCenter.Models;
using AppShoppingCenter.Services;
using ZXing.Net.Maui;

namespace AppShoppingCenter.Views.Tickets;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
		//cameraView.WidthRequest = DeviceDisplay.MainDisplayInfo.Width;
		//cameraView.HeightRequest = DeviceDisplay.MainDisplayInfo.Height;
    }

    public void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var ticketNumber = e.Results[0].Value;
        var service = App.Current.Handler.MauiContext.Services.GetService<TicketService>();
        var ticket = service.GetTicket(ticketNumber);
        if (ticket == null)
        {
            //Mensagem de alerta
            App.Current.MainPage.DisplayAlert("Ticket não encontrado", $"Não localizamos o ticket com o número {ticketNumber}", "OK");
            return;
        }
        //Navegar para a página pay
        var param = new Dictionary<string, object>()
                {
                            {"ticket", ticket}
                        };
        MainThread.BeginInvokeOnMainThread(async () => { await Shell.Current.GoToAsync("../pay", param); });
    }
}