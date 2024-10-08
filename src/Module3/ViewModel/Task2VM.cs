using Module3.Model;
using Module3.Model.Task2;
using Module3.View;
using System.ComponentModel;
using System.Windows.Input;

namespace Module3.ViewModel
{
    public class Task2VM : INotifyPropertyChanged
    {
        private string _lastMessage;
        private string _lastCall;
        private string _lastEmail;
        private readonly Random _random;
        private readonly Notification _notification;


        // Списки сообщений
        private readonly List<string> _messages = new()
    {
        "Привет! Как дела?",
        "Новое сообщение отправлено.",
        "Не забудь проверить почту.",
        "Как прошел твой день?",
        "Уведомление: новое сообщение!",
    };

        private readonly List<string> _calls = new()
        {
        "Звонок: Входящий вызов.",
        "Ты звонишь другу.",
        "Новый звонок начат.",
        "Телефонный вызов отправлен.",
        "Внимание: новый звонок!",
    };

        private readonly List<string> _emails = new()
    {
        "Письмо отправлено успешно!",
        "Проверь почту для нового письма.",
        "Email отправлен.",
        "Новое письмо в пути.",
        "Сообщение отправлено по email.",
    };

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
        public ICommand SendCallCommand { get; }
        public ICommand SendEmailCommand { get; }

        public Task2VM()
        {
            _notification = new Notification();
            _random = new Random();

            // Подписка на события
            _notification.MessageReceived += OnMessageReceived;
            _notification.CallReceived += OnCallReceived;
            _notification.EmailReceived += OnEmailReceived;

            // Инициализация команды
            SendMessageCommand = new RelayCommand(SendMessage);
            SendCallCommand = new RelayCommand(SendCall);
            SendEmailCommand = new RelayCommand(SendEmail);
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

        // Метод для отправки случайного сообщения
        private void SendMessage()
        {
            string randomMessage = _messages[_random.Next(_messages.Count)];
            _notification.SendMessage(randomMessage);
        }

        // Метод для отправки случайного звонка
        private void SendCall()
        {
            string randomCallMessage = _calls[_random.Next(_calls.Count)];
            _notification.MakeCall(randomCallMessage);
        }

        // Метод для отправки случайного email
        private void SendEmail()
        {
            string randomEmailMessage = _emails[_random.Next(_emails.Count)];
            _notification.SendEmail(randomEmailMessage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
