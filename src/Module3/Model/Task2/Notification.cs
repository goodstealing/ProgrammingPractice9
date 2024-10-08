using System;

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
        public event EventHandler<NotificationEventArgs> MessageReceived;
        public event EventHandler<NotificationEventArgs> CallReceived;
        public event EventHandler<NotificationEventArgs> EmailReceived;

        public void SendMessage(string message)
        {
            OnMessageReceived(new NotificationEventArgs(message));
        }

        public void MakeCall(string message)
        {
            OnCallReceived(new NotificationEventArgs(message));
        }

        public void SendEmail(string message)
        {
            OnEmailReceived(new NotificationEventArgs(message));
        }

        protected virtual void OnMessageReceived(NotificationEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }

        protected virtual void OnCallReceived(NotificationEventArgs e)
        {
            CallReceived?.Invoke(this, e);
        }

        protected virtual void OnEmailReceived(NotificationEventArgs e)
        {
            EmailReceived?.Invoke(this, e);
        }
    }
}
