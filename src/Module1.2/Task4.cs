using System;

namespace Module1_2
{
    internal class Task4
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Создание массива из 10 целых чисел
            int[] numbers = CreateArray(10);

            // Заполнение массива случайными числами
            FillArrayWithRandomNumbers(numbers);

            // Вывод элементов массива
            PrintArray(numbers);

            // Вычисление суммы всех элементов массива
            int sum = CalculateSum(numbers);
            Console.CursorVisible = false;
            Console.WriteLine($"Сумма всех элементов массива: {sum}");
        }

        /// <summary>
        /// Создает массив указанного размера.
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <returns>Массив целых чисел заданного размера</returns>
        static int[] CreateArray(int size)
        {
            return new int[size];
        }

        /// <summary>
        /// Заполняет массив случайными числами от 0 до 100.
        /// </summary>
        /// <param name="array">Массив</param>
        static void FillArrayWithRandomNumbers(int[] array)
        {
            Random random = new(); 
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 101);
            }
        }

        /// <summary>
        /// Выводит все элементы массива в консоль.
        /// </summary>
        /// <param name="array">Массив</param>
        static void PrintArray(int[] array)
        {
            Console.WriteLine("Элементы массива:");
            foreach (int number in array)
            {
                Console.WriteLine(number); // Вывод каждого элемента массива
            }
        }

        /// <summary>
        /// Вычисляет сумму всех элементов массива.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <returns>Сумма всех элементов массива</returns>
        static int CalculateSum(int[] array)
        {
            int sum = 0; // Переменная для хранения суммы
            foreach (int number in array)
            {
                sum += number;
            }
            return sum; 
        }
    }
}
