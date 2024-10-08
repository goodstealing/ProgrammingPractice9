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
            DataContext = new ConnectorViewModel();
        }

        new void MouseMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed) { DragMove(); }
        }
    }
}
