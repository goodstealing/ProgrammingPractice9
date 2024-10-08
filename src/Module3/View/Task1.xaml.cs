using System.Windows;
using System.Windows.Input;
using Module3.ViewModel;


namespace Module3.View
{
    public partial class Task1 : Window
    {
        public Task1()
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
