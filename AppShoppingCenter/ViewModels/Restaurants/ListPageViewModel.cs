using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Restaurants
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string searchText;

        private List<Establishment> restaurantsFull;

        [ObservableProperty]
        private List<Establishment> restaurantsFiltered;

        public ListPageViewModel()
        {
            var service = App.Current.Handler.MauiContext.Services.GetService<RestaurantService>();
            restaurantsFull = service.GetRestaurants();
            restaurantsFiltered = restaurantsFull;
        }

        [RelayCommand]
        private void OnSearchTextChanged()
        {
            // Filter the list of restaurants based on the search text
            RestaurantsFiltered = restaurantsFull.Where(restaurant => restaurant.Name.ToLower().Contains(SearchText.ToLower())).ToList();
        }
        
        [RelayCommand]
        private void OnRestaurantTapGoToDetailPage(Establishment establishment)
        {
            var parameter = new Dictionary<string, object>()
            {
                {"establishment", establishment }
            };
            Shell.Current.GoToAsync("detail", parameter);
        }
    }
}
