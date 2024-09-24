using System;

namespace Module1
{
    internal class Task2
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите радиус круга: ");
            string? userinput = Console.ReadLine();
            double radius;

            // Попытка преобразовать ввод в действительное число
            if (double.TryParse(userinput, out radius))
            {
                Console.WriteLine($"Вы ввели число: {radius}");
                var s = Math.PI * radius; // Формула площади круга по радиусу

                Console.WriteLine($"Площадь круга: {s}");
                Console.CursorVisible = false;

            }
            else
            {
                Console.WriteLine("/Введено некорректное значение, введите действительное число./");
            }
        }
    }
}
