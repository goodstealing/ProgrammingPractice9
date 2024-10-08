using Module3.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Module3.View
{
    public partial class Task4 : Window
    {
        public Task4()
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
