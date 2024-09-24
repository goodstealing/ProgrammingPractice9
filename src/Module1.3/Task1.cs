using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1_3
{
    internal class Task1
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Ввод дроби с клавиатуры
            (int numerator, int denominator) = InputFraction();

            // Вычисление НОД
            int gcd = CalculateGCD(numerator, denominator);

            // Сокращение дроби
            (int reducedNumerator, int reducedDenominator) = ReduceFraction(numerator, denominator, gcd);
            Console.CursorVisible = false;
            Console.WriteLine($"Сокращённая дробь: {reducedNumerator}/{reducedDenominator}");
        }

        /// <summary>
        /// Метод для ввода дроби с клавиатуры.
        /// </summary>
        /// <returns>Кортеж содержащий числитель и знаменатель дроби.</returns>
        private static (int, int) InputFraction()
        {
            Console.Write("Введите числитель (неотрицательное целое число): ");
            int numerator = int.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель (положительное целое число): ");
            int denominator;

            // Проверка корректности ввода знаменателя
            while (!int.TryParse(Console.ReadLine(), out denominator) || denominator <= 0)
            {
                Console.WriteLine("Ошибка! Знаменатель должен быть положительным целым числом. Попробуйте ещё раз:");
            }

            return (numerator, denominator);
        }

        /// <summary>
        /// Метод для вычисления НОД двух чисел с использованием алгоритма Евклида.
        /// </summary>
        /// <param name="a">Первое целое число.</param>
        /// <param name="b">Второе целое число.</param>
        /// <returns>Наибольший общий делитель двух чисел.</returns>
        private static int CalculateGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b; // Остаток от деления
                a = temp;
            }
            return a; // НОД
        }

        /// <summary>
        /// Метод для сокращения дроби.
        /// </summary>
        /// <param name="numerator">Числитель дроби.</param>
        /// <param name="denominator">Знаменатель дроби.</param>
        /// <param name="gcd">НОД числителя и знаменателя.</param>
        /// <returns>Кортеж содержащий сокращённый числитель и знаменатель.</returns>
        private static (int, int) ReduceFraction(int numerator, int denominator, int gcd)
        {
            // Сокращение дроби с помощью НОД
            return (numerator / gcd, denominator / gcd);
        }
    }
}
