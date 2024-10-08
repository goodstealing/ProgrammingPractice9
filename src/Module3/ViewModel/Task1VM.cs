using System.Collections.ObjectModel;
using System.ComponentModel;
using Module3.Model;
using System.Windows.Input;
using Module3.Model.Task1;
using Module3.View;
using System.Windows;

namespace Module3.ViewModel
{
    public class Task1VM : INotifyPropertyChanged
    {
        private ObservableCollection<Shape> shapes;
        private string selectedShape;
        private double width;
        private double height;
        private double radius;
        private double area;

        public double Width
        {
            get => width;
            set
            {
                width = value;
                NotifyPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get => height;
            set
            {
                height = value;
                NotifyPropertyChanged(nameof(Height));
            }
        }

        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                NotifyPropertyChanged(nameof(Radius));
            }
        }

        public double Area
        {
            get => area;
            set
            {
                area = value;
                NotifyPropertyChanged(nameof(Area));
            }
        }

        public string SelectedShape
        {
            get => selectedShape;
            set
            {
                selectedShape = value;
                NotifyPropertyChanged(nameof(SelectedShape));
            }
        }

        public string[] ShapeOptions { get; } = { "Круг", "Прямоугольник", "Треугольник" };

        public ICommand CalculateAreaCommand { get; }

        public Task1VM()
        {
            CalculateAreaCommand = new RelayCommand(CalculateArea);
        }

        private void CalculateArea()
        {
            Shape ?shape = null;

            switch (SelectedShape)
            {
                case "Круг":
                    shape = new Circle(Radius);
                    break;
                case "Прямоугольник":
                    shape = new Rectangle(Width, Height);
                    break;
                case "Треугольник":
                    shape = new Triangle(Width, Height);
                    break;
            }

            if (shape != null)
            {
                AreaCalculator calculator = shape.CalculateArea;
                Area = calculator();
            }
        }

        public ObservableCollection<Shape> Shapes
        {
            get { return shapes; }
            set
            {
                shapes = value;
                NotifyPropertyChanged(nameof(Shapes));
            }
        }

        #region КОМАНДЫ ОТКРЫТИЯ ОКОН
        private RelayCommand openNewTask1;
        public RelayCommand OpenNewTask1
        {
            get
            {
                return openNewTask1 ?? new RelayCommand(obj =>
                {
                    OpenTask1();
                });
            }
        }

        private RelayCommand openNewTask2;
        public RelayCommand OpenNewTask2
        {
            get
            {
                return openNewTask2 ?? new RelayCommand(obj =>
                {
                    OpenTask2();
                });
            }
        }

        private RelayCommand openNewTask3;
        public RelayCommand OpenNewTask3
        {
            get
            {
                return openNewTask3 ?? new RelayCommand(obj =>
                {
                    OpenTask3();
                });
            }
        }

        private RelayCommand openNewTask4;
        public RelayCommand OpenNewTask4
        {
            get
            {
                return openNewTask4 ?? new RelayCommand(obj =>
                {
                    OpenTask4();
                });
            }
        }

        private RelayCommand openNewTask5;
        public RelayCommand OpenNewTask5
        {
            get
            {
                return openNewTask5 ?? new RelayCommand(obj =>
                {
                    OpenTask5();
                });
            }
        }
        #endregion


        #region МЕТОДЫ ОТКРЫТИЯ ОКОН
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
            Task3 task3 = new();
            SendCenterPositionAndOpen(task3);
        }

        private void OpenTask4()
        {
            Task3 task4 = new();
            SendCenterPositionAndOpen(task4);
        }

        private void OpenTask5()
        {
            Task5 task5 = new();
            SendCenterPositionAndOpen(task5);
        }
        #endregion



        private void SendCenterPositionAndOpen(Window window)
        {
            // Центрируем и показываем новое окно
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner = Application.Current.MainWindow;

            // Скрываем главное окно (или закрываем, если это нужно)
            Application.Current.MainWindow.Hide();

            // Показываем новое окно
            window.Show(); // Используйте ShowDialog для модальных окон
        }


        private RelayCommand exitToMainCommand;
        public RelayCommand ExitToMainCommand
        {
            get
            {
                return exitToMainCommand ?? new RelayCommand(obj =>
                {
                    ReturnToMain();
                });
            }
        }

        private void ReturnToMain()
        {
            // Найти текущее окно и закрыть его
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (currentWindow != null)
            {
                // Вернуть на главное окно
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.Left = currentWindow.Left; // сохраняем позицию
                Application.Current.MainWindow.Top = currentWindow.Top;

                // Закрыть текущее окно
                currentWindow.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
