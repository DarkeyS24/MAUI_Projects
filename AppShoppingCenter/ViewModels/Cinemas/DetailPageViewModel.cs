using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Models;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Cinemas
{
    [QueryProperty(nameof(Movie),"movie")]
    public partial class DetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Movie movie;
    }
}
