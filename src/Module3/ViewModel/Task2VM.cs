using Module3.Model.Task2;
using System.ComponentModel;
using System.Windows.Input;

namespace Module3.ViewModel
{
    public class Task2VM : INotifyPropertyChanged
    {
        private string _lastMessage;
        private string _lastCall;
        private string _lastEmail;

        public string LastMessage
        {
            get => _lastMessage;
            set
            {
                _lastMessage = value;
                NotifyPropertyChanged(nameof(LastMessage));
            }
        }

        public string LastCall
        {
            get => _lastCall;
            set
            {
                _lastCall = value;
                NotifyPropertyChanged(nameof(LastCall));
            }
        }

        public string LastEmail
        {
            get => _lastEmail;
            set
            {
                _lastEmail = value;
                NotifyPropertyChanged(nameof(LastEmail));
            }
        }

        public ICommand SendMessageCommand { get; }

        private readonly Notification _notification;

        public Task2VM()
        {
            _notification = new Notification();

            // Регистрация обработчиков событий
            _notification.MessageReceived += OnMessageReceived;
            _notification.CallReceived += OnCallReceived;
            _notification.EmailReceived += OnEmailReceived;

            // Инициализация команды
            SendMessageCommand = new RelayCommand(SendMessage);

            // Пример отправки уведомлений
            _notification.SendMessage("Hello! You have a new message.");
            _notification.MakeCall("Incoming call from +123456789.");
            _notification.SendEmail("New email received from example@example.com.");
        }

        private void OnMessageReceived(object sender, NotificationEventArgs e)
        {
            LastMessage = e.Message;
        }

        private void OnCallReceived(object sender, NotificationEventArgs e)
        {
            LastCall = e.Message;
        }

        private void OnEmailReceived(object sender, NotificationEventArgs e)
        {
            LastEmail = e.Message;
        }

        private void SendMessage()
        {
            _notification.SendMessage("Hello! New message sent.");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Реализация ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();
    }
}
