﻿using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppTask.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PrevisionDate { get; set; }
        public  ObservableCollection<SubTaskModel> Sub_Tasks { get; set; } = new ObservableCollection<SubTaskModel>();
        private bool _isCompleted;
        public bool IsCompleted {
            get { return _isCompleted; }
            set { _isCompleted = value; OnPropertyChanged("IsCompleted"); }
        }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
