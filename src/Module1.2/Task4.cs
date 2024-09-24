using System;

namespace Module1_2
{
    internal class Task4
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Ввод данных: размер массива, границы диапазона для генерации случайных чисел
            int K = GetArraySize();
            int A = GetNumber("Введите начальное значение диапазона A: ");
            int B = GetNumber("Введите конечное значение диапазона B (не включая B): ");

            // Создание и заполнение массива случайными значениями
            int[] array = GenerateRandomArray(K, A, B);

            // Поиск индексов минимального и максимального элементов
            int minIndex = FindMinIndex(array);
            int maxIndex = FindMaxIndex(array);

            // Вывод элементов между минимальным и максимальным (включая их)
            PrintElementsBetweenMinMax(array, minIndex, maxIndex);
        }

        /// <summary>
        /// Метод для получения размера массива с проверкой на корректный ввод.
        /// </summary>
        /// <returns>Размер массива</returns>
        private static int GetArraySize()
        {
            Console.Write("Введите размер массива K: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Ошибка! Введите положительное целое число для размера массива.");
            }
            return size;
        }

        /// <summary>
        /// Метод для получения целочисленного значения с консоли с проверкой корректности ввода.
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <returns>Введённое целое число</returns>
        private static int GetNumber(string message)
        {
            Console.Write(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка! Введите целое число.");
                Console.Write(message);
            }
            return number;
        }

        /// <summary>
        /// Метод для генерации массива случайных целых чисел в заданном диапазоне [A, B).
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="A">Нижняя граница диапазона (включительно)</param>
        /// <param name="B">Верхняя граница диапазона (исключительно)</param>
        /// <returns>Сгенерированный массив</returns>
        private static int[] GenerateRandomArray(int size, int A, int B)
        {
            int[] array = new int[size];
            Random random = new(); 
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(A, B); // Генерация случайного числа в диапазоне [A, B)
            }

            Console.WriteLine("Сгенерированный массив:");
            Console.WriteLine(string.Join(", ", array));

            return array;
        }

        /// <summary>
        /// Метод для нахождения индекса минимального элемента в массиве.
        /// </summary>
        /// <param name="array">Массив для поиска</param>
        /// <returns>Индекс минимального элемента</returns>
        private static int FindMinIndex(int[] array)
        {
            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        /// <summary>
        /// Метод для нахождения индекса максимального элемента в массиве.
        /// </summary>
        /// <param name="array">Массив для поиска</param>
        /// <returns>Индекс максимального элемента</returns>
        private static int FindMaxIndex(int[] array)
        {
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// Метод для вывода элементов массива, расположенных между минимальным и максимальным индексами (включая их).
        /// </summary>
        /// <param name="array">Массив элементы которого выводятся</param>
        /// <param name="minIndex">Индекс минимального элемента</param>
        /// <param name="maxIndex">Индекс максимального элемента</param>
        private static void PrintElementsBetweenMinMax(int[] array, int minIndex, int maxIndex)
        {
            Console.CursorVisible = false;
            //  Порядок индексов, чтобы вывод был от меньшего к большему
            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            Console.WriteLine("Элементы массива между минимальным и максимальным элементами (включая их):");
            for (int i = start; i <= end; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
