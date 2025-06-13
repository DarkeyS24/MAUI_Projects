using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppTask.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset PrevisionDate { get; set; }
        public  ObservableCollection<SubTaskModel> Sub_Tasks { get; set; } = new ObservableCollection<SubTaskModel>();
        private bool _isCompleted;
        public bool IsCompleted {
            get { return _isCompleted; }
            set { _isCompleted = value; OnPropertyChanged("IsCompleted"); }
        }

        public Guid UserId { get; set; }
        public UserModel? User { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public DateTimeOffset Deleted { get; set; }

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
