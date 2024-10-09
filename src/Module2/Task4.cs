using System;

// Определяем интерфейс IDrawable
namespace Module2 
{ 

    public interface IDrawable
    {
        public static void Execute()
        {
            // Массив объектов, реализующих интерфейс IDrawable
            IDrawable[] shapes =
            [
                new Circle2(5),
                new Rectangle2(4, 7),
                new Triangle(3, 6)
            ];

            // Вызов метода Draw() для каждого объекта в массиве
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
        void Draw();
    }

    // Circle, реализующий интерфейс IDrawable
    public class Circle2 : IDrawable
    {
        public double Radius { get; set; }

        public Circle2(double radius)
        {
            Radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Рисуем круг с радиусом: {Radius}");
        }
    }

    // Rectangle, реализующий интерфейс IDrawable
    public class Rectangle2 : IDrawable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle2(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Рисуем прямоугольник с шириной: {Width} и высотой: {Height}");
        }
    }

    // Triangle, реализующий интерфейс IDrawable
    public class Triangle : IDrawable
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Рисуем треугольник с основанием: {Base} и высотой: {Height}");
        }
    }
}
