using Module3.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.ViewModel
{
    public class ConnectorViewModel : INotifyPropertyChanged
    {
        public Task1VM Task1VM { get; set; }
        public Task2VM Task2VM { get; set; }
        public MainViewModel mainViewModel { get; set; }
        public ConnectorViewModel() 
        {
            Task1VM = new Task1VM();
            Task2VM = new Task2VM();
            mainViewModel = new MainViewModel(); 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
