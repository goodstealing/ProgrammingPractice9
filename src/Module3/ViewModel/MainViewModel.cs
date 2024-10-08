using Module3.Model;
using Module3.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Module3.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Команды открытия окон

        private readonly RelayCommand? openNewTask1;
        public RelayCommand OpenNewTask1 => openNewTask1 ?? new RelayCommand(_ => OpenTask1());

        private readonly RelayCommand? openNewTask2;
        public RelayCommand OpenNewTask2 => openNewTask2 ?? new RelayCommand(_ => OpenTask2());

        private readonly RelayCommand? openNewTask3;
        public RelayCommand OpenNewTask3 => openNewTask3 ?? new RelayCommand(_ => OpenTask3());

        private readonly RelayCommand? openNewTask4;
        public RelayCommand OpenNewTask4 => openNewTask4 ?? new RelayCommand(_ => OpenTask4());

        private readonly RelayCommand? openNewTask5;
        public RelayCommand OpenNewTask5 => openNewTask5 ?? new RelayCommand(_ => OpenTask5());

        #endregion

        #region Методы открытия окон

        private void OpenTask1()
        {
            Task1 task1Window = new();
            SendCenterPositionAndOpen(task1Window);
        }

        private void OpenTask2()
        {
            Task2 task2Window = new();
            SendCenterPositionAndOpen(task2Window);
        }

        private void OpenTask3()
        {
            Task3 task3Window = new();
            SendCenterPositionAndOpen(task3Window);
        }

        private void OpenTask4()
        {
            Task4 task4Window = new();
            SendCenterPositionAndOpen(task4Window);
        }

        private void OpenTask5()
        {
            Task5 task5Window = new();
            SendCenterPositionAndOpen(task5Window);
        }

        private void SendCenterPositionAndOpen(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner = Application.Current.MainWindow;

            Application.Current.MainWindow.Hide(); // Скрываем главное окно
            window.Show();
        }

        #endregion

        #region Команда возврата на главное окно

        private readonly RelayCommand? exitToMainCommand;
        public RelayCommand ExitToMainCommand => exitToMainCommand ?? new RelayCommand(_ => ReturnToMain());

        private static void ReturnToMain()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive && w != Application.Current.MainWindow);

            if (currentWindow != null)
            {
                // Показать главное окно
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.Left = currentWindow.Left;  // Переносим координаты
                Application.Current.MainWindow.Top = currentWindow.Top;

                currentWindow.Close();  // Закрываем текущее окно
            }
        }

        #endregion

        #region Команды работы с окном

        public ICommand CloseCommand { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }

        public MainViewModel()
        {
            CloseCommand = new RelayCommand(_ => Close());
            MinimizeCommand = new RelayCommand(_ => Minimize());
            MaximizeCommand = new RelayCommand(_ => Maximize());

        }

        private void Close() => Application.Current.Shutdown();

        private void Minimize()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.WindowState = WindowState.Minimized; // Минимизация окна
            }
        }

        private void Maximize()
        {
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.WindowState = currentWindow.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized; // Максимизация окна
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
