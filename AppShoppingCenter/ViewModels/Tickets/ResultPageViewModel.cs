using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppShoppingCenter.ViewModels.Tickets
{
    [QueryProperty(nameof(Ticket),"ticket")]
    public partial class ResultPageViewModel : ObservableObject
    {
        private Ticket ticket;
        public Ticket Ticket
        {
            get { return ticket; }
            set { SetPermanenceTime(value); SetProperty(ref ticket, value); }
        }

        [ObservableProperty]
        private string permanenceTime;

        [ObservableProperty]
        private int tolerance = 30;

        private void SetPermanenceTime(Ticket ticket)
        {
            var dif = ticket.DateOut.Ticks - ticket.DateIn.Ticks;
            var difTS = new TimeSpan(dif);
            PermanenceTime = string.Format("{0:D2}h {1:D2}m", difTS.Hours, difTS.Minutes);
        }
    }
}
