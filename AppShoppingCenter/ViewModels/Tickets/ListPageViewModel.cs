﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Libraries.Converters;
using AppShoppingCenter.Libraries.Storages;
using AppShoppingCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Ticket> tickets;

        public ListPageViewModel()
        {
            var storage = App.Current.Handler.MauiContext.Services.GetService<TicketPreferenceStorage>();
            Tickets = storage.Load();
        }
    }
}
