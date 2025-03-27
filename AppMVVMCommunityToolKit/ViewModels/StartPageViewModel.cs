using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppMVVMCommunityToolKit.Libraries.Messages;
using AppMVVMCommunityToolKit.Models;
using AppMVVMCommunityToolKit.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AppMVVMCommunityToolKit.ViewModels
{
    public partial class StartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string message;

        [ObservableProperty]
        private Person person;
        public ObservableCollection<Person> People { get; set; }
        
        public StartPageViewModel()
        {
            Person = new Person();
            People = [];
            WeakReferenceMessenger.Default.Register<TextMessage>(this, (obj, msg) => Message = msg.Value);
            WeakReferenceMessenger.Default.Register<PersonMessage>(this, (obj, msg) => People.Add(msg.Value));
        }

        [RelayCommand]
        private void Save()
        {
            People.Add(Person);
            Person = new Person();
        }

        [RelayCommand]
        private void GoToSubPage()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            navPage.PushAsync(new PubSubPage());
        }
    }
}
