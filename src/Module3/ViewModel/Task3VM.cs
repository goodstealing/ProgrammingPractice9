using Module3.Model;
using Module3.Model.Task3;
using Module3.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module3.ViewModel
{
    public class Task3VM : INotifyPropertyChanged
    {
        public ObservableCollection<TaskModel> Tasks { get; set; }

        private string _newTaskDescription;
        public string NewTaskDescription
        {
            get => _newTaskDescription;
            set
            {
                _newTaskDescription = value;
                NotifyPropertyChanged(nameof(NewTaskDescription)); // Передаем имя свойства вручную
            }
        }


        public ICommand AddTaskCommand { get; }

        public Task3VM()
        {
            Tasks = new ObservableCollection<TaskModel>();
            AddTaskCommand = new RelayCommand(AddTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskDescription))
            {
                var task = new TaskModel(NewTaskDescription);
                Tasks.Add(task);
                NewTaskDescription = string.Empty; // Очистка после добавления
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
