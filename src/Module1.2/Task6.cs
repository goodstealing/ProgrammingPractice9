using System;

namespace Module1_2
{
    internal class Task6
    {
        private const int ArraySize = 10; // Размер массива

        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;
            double[] values = GenerateRandomArray(ArraySize, -10, 10);

            Console.WriteLine("Исходный массив:");
            PrintArray(values);

            // Получение массива индексов, отсортированных по значениям массива
            int[] sortedIndices = GetSortedIndices(values);
            Console.WriteLine("Индексы элементов в порядке возрастания значений:");
            PrintArray(sortedIndices);
        }

        /// <summary>
        /// Генерирует массив случайных вещественных чисел в заданном диапазоне.
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="minValue">Минимальное значение диапазона</param>
        /// <param name="maxValue">Максимальное значение диапазона</param>
        /// <returns>Массив случайных вещественных чисел</returns>
        private static double[] GenerateRandomArray(int size, double minValue, double maxValue)
        {
            Random random = new();
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                // Заполнение массива случайными вещественными числами в диапазоне [minValue, maxValue)
                array[i] = random.NextDouble() * (maxValue - minValue) + minValue;
            }

            return array;
        }

        /// <summary>
        /// Получает массив индексов, отсортированных по значениям исходного массива.
        /// </summary>
        /// <param name="values">Массив вещественных чисел</param>
        /// <returns>Массив индексов, отсортированных по возрастанию значений</returns>
        private static int[] GetSortedIndices(double[] values)
        {
            int[] indices = new int[values.Length];

            // Заполнение массива индексов от 0 до length-1
            for (int i = 0; i < values.Length; i++)
            {
                indices[i] = i;
            }

            // Сортировка индексов по значениям в массиве values
            Array.Sort(values, indices);
            return indices;
        }

        /// <summary>
        /// Выводит элементы массива в консоль.
        /// </summary>
        /// <param name="array">Массив для вывода</param>
        private static void PrintArray(double[] array)
        {
            foreach (double value in array)
            {
                Console.WriteLine(value); // Вывод каждого элемента массива
            }
        }

        /// <summary>
        /// Выводит элементы массива индексов в консоль.
        /// </summary>
        /// <param name="array">Массив индексов</param>
        private static void PrintArray(int[] array)
        {
            Console.CursorVisible = false;
            foreach (int index in array)
            {
                Console.WriteLine(index); // Вывод каждого индекса
            }
        }
    }
}
