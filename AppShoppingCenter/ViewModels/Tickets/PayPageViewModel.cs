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
    public partial class PayPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Ticket ticket;
    }
}
