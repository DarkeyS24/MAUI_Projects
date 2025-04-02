using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Services;
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
            Shell.Current.GoToAsync("pay");
        }
        
        [RelayCommand]
        private void List()
        {
            Shell.Current.GoToAsync("list");
        }
        
        [RelayCommand]
        private void CheckTicketNumber()
        {
            if (TicketNumber?.Length < 15)
            return;

            //Verificar se o codigo existe no Banco de Dados/API.
            var service = App.Current.Handler.MauiContext.Services.GetService<TicketService>();
            var ticket = service.GetTicket(TicketNumber);
            if (ticket == null)
            {
                //Mensagem de alerta
                App.Current.MainPage.DisplayAlert("Ticket não encontrado", $"Não localizamos o ticket com o número {TicketNumber}", "OK");
                return;
            }
                //Navegar para a página pay
                var param = new Dictionary<string, object>()
                {
                    {"ticket", ticket}
                };
                Shell.Current.GoToAsync("list", param);
                TicketNumber = string.Empty;
        }
    }
}
