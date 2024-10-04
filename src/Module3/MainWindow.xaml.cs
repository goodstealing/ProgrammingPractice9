using System.Windows;
using System.Windows.Input;

namespace Module3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает окно
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; // Сворачивает окно
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; // Восстанавливает размер окна
            }
            else
            {
                this.WindowState = WindowState.Maximized; // Разворачивает окно на весь экран
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Проверяем, что пользователь нажал левой кнопкой мыши
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove(); // Перемещаем окно
            }
        }
    }
}