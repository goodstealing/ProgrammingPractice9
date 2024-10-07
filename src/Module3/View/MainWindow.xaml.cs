using Module3.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Module3.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Task1VM();
        }

        void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        void MinimizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal; // Восстановление размера окна
            }
            else
            {
                WindowState = WindowState.Maximized; // Окно на весь экран
            }
        }

        void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Если ЛКМ
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove(); // Перемещение окна
            }
        }

    }
}