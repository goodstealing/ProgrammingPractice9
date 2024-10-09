using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Module3.Model;
using Module3.Model.Task1;

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
            Shape shape = null;

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
