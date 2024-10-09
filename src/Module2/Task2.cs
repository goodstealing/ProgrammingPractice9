using System;

namespace Module2
{
    internal class Task2
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Создание объекта класса Circle с радиусом 4
            Shape circle = new Circle(4);
            Console.WriteLine($"Круг: Площадь = {circle.Area():0.00}; Периметр = {circle.Perimeter():0.00}.");

            // Создание объекта класса Rectangle с шириной 14 и высотой 5
            Shape rectangle = new Rectangle(14, 5);
            Console.WriteLine($"Прямоугольник: Площадь = {rectangle.Area():0.00}; Периметр = {rectangle.Perimeter():0.00}.");
        }
    }

    public abstract class Shape
    {
        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Circle : Shape
    {
        private readonly double radius;

        // Конструктор круга
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double Area() => Math.PI * Math.Pow(radius, 2);

        public override double Perimeter() => 2 * Math.PI * radius;
    }

    public class Rectangle : Shape
    {
        private readonly double width;
        private readonly double height;

        // Конструктор прямоугольника
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area() => width * height;

        public override double Perimeter() => 2 * (width + height);
    }
}
