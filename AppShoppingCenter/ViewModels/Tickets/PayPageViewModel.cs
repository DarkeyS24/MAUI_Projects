using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Libraries.Storages;
using AppShoppingCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Tickets
{
    [QueryProperty(nameof(Ticket),"ticket")]
    public partial class PayPageViewModel : ObservableObject
    {
        private Ticket ticket;

        [ObservableProperty]
        private string permanenceTime;

        public Ticket Ticket 
        {
            get { return ticket; }
            set { GenerateObjectMissingValues(value); GenerateTicketPrice(value); SetProperty(ref ticket, value); }
        }

        [ObservableProperty]
        private string pIXCode = "00020126480014br.gov.bcb.pix0126angel.lperez.m16@gmail.com520400005303986540515.005802BR5921ANGEL LUIS PEREZ MATA6007TUBARAO62130509Mibillete6304E860";

        [RelayCommand]
        private async void CopyPIXCode()
        {
            await Clipboard.Default.SetTextAsync(PIXCode);
            await Task.Delay(3000);

            var storage = App.Current.Handler.MauiContext.Services.GetService<TicketPreferenceStorage>();
            storage.Save(Ticket);

            var param = new Dictionary<string, object>
            {
                {"ticket", ticket}
            };
            await Shell.Current.GoToAsync("../result", param);
        }

        private void GenerateObjectMissingValues(Ticket ticket)
        {
            var rd = new Random();
            var hour = rd.Next(0, 12);
            var minute = rd.Next(0, 60);
            ticket.DateOut = ticket.DateIn.AddHours(hour).AddMinutes(minute);
            ticket.DateTolerance = ticket.DateOut.AddMinutes(30);
        }

        private void GenerateTicketPrice(Ticket ticket)
        {
            var dif = ticket.DateOut.Ticks - ticket.DateIn.Ticks;
            var difTS = new TimeSpan(dif);

            ticket.Price = difTS.TotalMinutes * 0.07;
            PermanenceTime = string.Format("{0:D2}h {1:D2}m", difTS.Hours, difTS.Minutes);
        }
    }
}
