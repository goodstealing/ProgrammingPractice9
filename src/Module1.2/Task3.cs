using System;

namespace Module1_2
{
    internal class Task3
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Ввод значения K с клавиатуры
            int K = GetNumberOfPrimes();

            // Вычисление первых K простых чисел
            int[] primes = CalculatePrimes(K);

            // Вывод простых чисел по 10 на строке
            PrintPrimes(primes);
        }

        /// <summary>
        /// Метод для ввода количества простых чисел (K), которые нужно найти.
        /// </summary>
        /// <returns>Целое число K, введённое пользователем</returns>
        private static int GetNumberOfPrimes()
        {
            int K;
            Console.Write("Введите количество простых чисел, которое нужно найти: ");
            // Проверка на корректность ввода (K должно быть положительным числом)
            while (!int.TryParse(Console.ReadLine(), out K) || K <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное число.");
            }
            return K;
        }

        /// <summary>
        /// Метод для вычисления первых K простых чисел.
        /// </summary>
        /// <param name="K">Количество простых чисел которое нужно найти</param>
        /// <returns>Массив первых K простых чисел</returns>
        private static int[] CalculatePrimes(int K)
        {
            int[] primes = new int[K]; // Массив для хранения простых чисел
            int count = 0; // Счётчик найденных простых чисел
            int number = 2; // Начальное число для проверки 

            // Пока не найдено K простых чисел
            while (count < K)
            {
                // Является ли простым числом
                if (IsPrime(number))
                {
                    primes[count] = number; 
                    count++; 
                }
                number++; // Переходим к следующему числу
            }

            return primes;
        }

        /// <summary>
        /// Метод для проверки, является ли заданное число простым.
        /// Простое число делится только на себя и на 1.
        /// </summary>
        /// <param name="number">Число, которое нужно проверить</param>
        /// <returns>True, если число простое, иначе False</returns>
        private static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            // Проверка делимости числа на все числа от 2 до его квадратного корня
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false; // Если делится без остатка число не простое
            }

            return true; // Не простое число
        }

        /// <summary>
        /// Метод для вывода простых чисел по 10 на строке.
        /// </summary>
        /// <param name="primes">Массив простых чисел для вывода</param>
        private static void PrintPrimes(int[] primes)
        {
            Console.CursorVisible = false;
            // Переменная для отслеживания количества чисел, выведенных на одной строке
            int countInLine = 0;

            foreach (int prime in primes)
            {
                // Выводим простое число с отступом в одну строку
                Console.Write($"{prime,5} "); // {5} для аккуратного форматирования вывода

                countInLine++;

                // После каждого 10-го числа перенос на новую строку
                if (countInLine == 10)
                {
                    Console.WriteLine(); 
                    countInLine = 0; 
                }
            }

            if (countInLine != 0)
            {
                Console.WriteLine();
            }
        }
    }
}
