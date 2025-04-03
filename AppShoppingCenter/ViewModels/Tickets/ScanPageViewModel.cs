using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Services;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class ScanPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string ticketNumber;

        [RelayCommand]
        private void Scan()
        {
            Shell.Current.GoToAsync("camera");
        }
        
        [RelayCommand]
        private void List()
        {
            Shell.Current.GoToAsync("list");
        }
        
        [RelayCommand]
        private async void CheckTicketNumber(Entry entry)
        {
            if (TicketNumber?.Length < 15)
            return;

            //Verificar se o codigo existe no Banco de Dados/API.
            var service = App.Current.Handler.MauiContext.Services.GetService<TicketService>();
            var ticket = service.GetTicket(TicketNumber);
            if (ticket == null)
            {
                //Mensagem de alerta
                await App.Current.MainPage.DisplayAlert("Ticket não encontrado", $"Não localizamos o ticket com o número {TicketNumber}", "OK");
                return;
            }
                //Navegar para a página pay
                var param = new Dictionary<string, object>()
                {
                    {"ticket", ticket}
                };
                await Shell.Current.GoToAsync("pay", param);
                await entry.HideKeyboardAsync(CancellationToken.None);
                TicketNumber = string.Empty;
        }
    }
}
