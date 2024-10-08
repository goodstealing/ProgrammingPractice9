using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.Model.Task2
{
    public class NotificationEventArgs : EventArgs
    {
        public string Message { get; }

        public NotificationEventArgs(string message)
        {
            Message = message;
        }
    }

    public class Notification
    {
        // События для разных типов уведомлений
        public event EventHandler<NotificationEventArgs> ?MessageReceived;
        public event EventHandler<NotificationEventArgs> ?CallReceived;
        public event EventHandler<NotificationEventArgs> ?EmailReceived;

        // Метод для отправки сообщения
        public void SendMessage(string message)
        {
            OnMessageReceived(new NotificationEventArgs(message));
        }

        // Метод для отправки звонка
        public void MakeCall(string message)
        {
            OnCallReceived(new NotificationEventArgs(message));
        }

        // Метод для отправки электронного письма
        public void SendEmail(string message)
        {
            OnEmailReceived(new NotificationEventArgs(message));
        }

        // Вызов события получения сообщения
        protected virtual void OnMessageReceived(NotificationEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }

        // Вызов события получения звонка
        protected virtual void OnCallReceived(NotificationEventArgs e)
        {
            CallReceived?.Invoke(this, e);
        }

        // Вызов события получения электронного письма
        protected virtual void OnEmailReceived(NotificationEventArgs e)
        {
            EmailReceived?.Invoke(this, e);
        }
    }
}
