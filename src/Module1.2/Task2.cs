using System;

namespace Module1_2
{
    internal class Task2
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            double number1 = InputNumber("Введите первое число: ");
            double number2 = InputNumber("Введите второе число: ");
            double number3 = InputNumber("Введите третье число: ");

            // Вычисление среднего арифметического
            double average = CalculateAverage(number1, number2, number3);
            DisplayResult(average);
        }

        /// <summary>
        /// Метод для ввода числа от пользователя с проверкой корректности ввода.
        /// </summary>
        /// <param name="prompt">Сообщение для ввода числа</param>
        /// <returns>Введённое число</returns>
        private static double InputNumber(string prompt)
        {
            double number;
            Console.Write(prompt); // Выводим сообщение для пользователя
            while (!double.TryParse(Console.ReadLine(), out number)) // Проверка корректность ввода
            {
                Console.WriteLine("Ошибка! Введите корректное число.");
                Console.Write(prompt); // Повторный вывод сообщения
            }
            return number; // Возврат введённого числа
        }

        /// <summary>
        /// Метод для вычисления среднего арифметического трёх чисел.
        /// </summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <param name="num3">Третье число</param>
        /// <returns>Среднее арифметическое трёх чисел</returns>
        private static double CalculateAverage(double num1, double num2, double num3)
        {
            return (num1 + num2 + num3) / 3; // Формула среднего арифметического
        }

        /// <summary>
        /// Метод для вывода результата среднего арифметического на экран.
        /// </summary>
        /// <param name="average">Среднее арифметическое</param>
        private static void DisplayResult(double average)
        {
            Console.CursorVisible = false;
            Console.WriteLine($"Среднее арифметическое введённых чисел: {average:F2}");
            // {F2} форматирует результат до двух знаков после запятой
        }
    }
}
