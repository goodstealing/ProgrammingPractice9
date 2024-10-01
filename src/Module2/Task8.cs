using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    internal class Task8
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(4, 6);
            Shape triangle = new Triangle(3, 7);

            circle.DisplayInfo();      
            rectangle.DisplayInfo();   
            triangle.DisplayInfo();  
        }

        public abstract class Shape
        {
            // Абстрактный метод для вычисления площади
            public abstract double CalculateArea();

            // Метод для вывода информации о фигуре
            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Площадь фигуры: {CalculateArea():F2}");
            }
        }

        // Производный класс "Круг"
        public class Circle : Shape
        {
            public double Radius { get; set; }

            // Конструктор
            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double CalculateArea()
            {
                return Math.PI * Math.Pow(Radius, 2);
            }

            // Переопределение метода для вывода информации
            public override void DisplayInfo()
            {
                Console.WriteLine($"Круг с радиусом {Radius}");
                base.DisplayInfo();
            }
        }

        // Производный класс "Прямоугольник"
        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            // Конструктор
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            // Реализация метода для вычисления площади прямоугольника
            public override double CalculateArea()
            {
                return Width * Height;
            }

            // Переопределение метода для вывода информации
            public override void DisplayInfo()
            {
                Console.WriteLine($"Прямоугольник с шириной {Width} и высотой {Height}");
                base.DisplayInfo();
            }
        }

        // Производный класс "Треугольник"
        public class Triangle : Shape
        {
            public double Base { get; set; }
            public double Height { get; set; }

            // Конструктор
            public Triangle(double triangleBase, double height)
            {
                Base = triangleBase;
                Height = height;
            }

            // Реализация метода для вычисления площади треугольника
            public override double CalculateArea()
            {
                return 0.5 * Base * Height;
            }

            // Переопределение метода для вывода информации
            public override void DisplayInfo()
            {
                Console.WriteLine($"Треугольник с основанием {Base} и высотой {Height}");
                base.DisplayInfo();
            }
        }
    }
}
