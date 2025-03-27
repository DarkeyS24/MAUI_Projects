using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppMVVM.Models;

namespace AppMVVM.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        #region Person to form
        public ICommand SaveCommand { get; set; }
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { _person = value; OnPropertyChanged(nameof(Person)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region List
        public ObservableCollection<Person> People { get; set; }
        #endregion

        public StartPageViewModel()
        {
            SaveCommand = new Command(Save);    
            Person = new Person();
            People = [];
        }

        private void Save()
        {
            // Save the person
            People.Add(Person);
            Person = new Person();
        }
    }
}
