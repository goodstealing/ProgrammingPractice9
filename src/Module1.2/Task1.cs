using System;

namespace Module1_2
{
    internal class Task1
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Ввод размера массива
            int N = GetArraySize();

            // Создание массива и ввод элементов
            double[] array = InputArrayElements(N);
            Console.CursorVisible = false;

            // Нахождение максимального по модулю элемента
            double maxAbsValue = FindMaxAbsValue(array);

            if (maxAbsValue == 0)
            {
                Console.WriteLine("Нормирование невозможно, все элементы массива равны 0.");
                return;
            }

            // Нормирование массива и вывод
            NormalizeArray(array, maxAbsValue);
            PrintArray(array);
        }

        /// <summary>
        /// Метод для ввода размера массива с проверкой корректности ввода.
        /// </summary>
        /// <returns>Размер массива</returns>
        private static int GetArraySize()
        {
            int N;
            Console.Write("Введите размер массива N: ");
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное число для размера массива.");
            }
            return N;
        }

        /// <summary>
        /// Метод для ввода элементов массива с проверкой корректности ввода.
        /// </summary>
        /// <param name="N">Размер массива</param>
        /// <returns>Заполненный массив</returns>
        private static double[] InputArrayElements(int N)
        {
            double[] array = new double[N];
            Console.WriteLine("Ввод элементов массива:");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                while (!double.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                    Console.Write($"Элемент {i + 1}: ");
                }
            }
            return array;
        }

        /// <summary>
        /// Метод для нахождения максимального по модулю элемента массива.
        /// </summary>
        /// <param name="array">Массив элементов</param>
        /// <returns>Максимальное значение по модулю</returns>
        private static double FindMaxAbsValue(double[] array)
        {
            return array.Max(Math.Abs); // Поиск максимального значения по модулю
        }

        /// <summary>
        /// Метод для нормирования массива, делением каждого элемента на максимальный по модулю.
        /// </summary>
        /// <param name="array">Массив для нормирования</param>
        /// <param name="maxAbsValue">Максимальное по модулю значение, на которое делится элемент</param>
        private static void NormalizeArray(double[] array, double maxAbsValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] /= maxAbsValue; // Нормирование
            }
        }

        /// <summary>
        /// Метод для вывода элементов массива.
        /// </summary>
        /// <param name="array">Массив для вывода</param>
        private static void PrintArray(double[] array)
        {
            Console.WriteLine("Нормированный массив:");
            foreach (double value in array)
            {
                Console.WriteLine(value); // Вывод каждого элемента
            }
        }
    }
}
