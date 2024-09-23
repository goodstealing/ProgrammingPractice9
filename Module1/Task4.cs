using System;

namespace Module1
{
    internal class Task4
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            int[] arr_numbers = GenRandomArr(20);

            // Макс. и мин. значения
            int max = FindMax(arr_numbers);
            int min = FindMin(arr_numbers);

            Console.WriteLine("Сгенерированный массив: " + string.Join(", ", arr_numbers));
            Console.WriteLine("Максимальное значение: " + max);
            Console.WriteLine("Минимальное значение: " + min);
        }

        /// <summary>
        /// Генерирует массив случайных целых чисел заданного размера.
        /// </summary>
        /// <param name="size">Размер массива.</param>
        /// <returns>Массив случайных целых чисел.</returns>
        static int[] GenRandomArr(int size)
        {
            Random random = new();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101); // Числа от 1 до 100
            }

            return array;
        }

        /// <summary>
        /// Находит максимальное значение в массиве.
        /// </summary>
        /// <param name="array">Массив целых чисел.</param>
        /// <returns>Максимальное значение в массиве.</returns>
        static int FindMax(int[] array)
        {
            int max = array[0]; // Инициализация макс. значения первым элементом

            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num; // Обновление макс. значения если найдено меньшее
                }
            }

            return max;
        }

        /// <summary>
        /// Находит минимальное значение в массиве.
        /// </summary>
        /// <param name="array">Массив целых чисел.</param>
        /// <returns>Минимальное значение в массиве.</returns>
        static int FindMin(int[] array)
        {
            int min = array[0]; // Инициализация мин. значения первым элементом

            foreach (int num in array)
            {
                if (num < min)
                {
                    min = num; // Обновление мин. значения если найдено меньшее
                }
            }

            return min;
        }

    }
}
