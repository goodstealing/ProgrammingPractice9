using System;

namespace Module1_2
{
    internal class Task2
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            int[] array = { 3, 7, 12, 5, 2, 8, 1, 15, 4, 10 };
            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            
            Console.Write("Введите целое число для замены максимального элемента: ");
            int inputNumber = int.Parse(Console.ReadLine());

            Console.CursorVisible = false;
            // Замена максимального элемента введенным числом
            ReplaceMaxElement(array, inputNumber);
            Console.WriteLine("Массив после замены максимального элемента:");
            PrintArray(array);
        }

        /// <summary>
        /// Метод для вывода элементов массива на экран.
        /// </summary>
        /// <param name="array">Массив</param>
        static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine(); // Переход на новую строку после вывода всех элементов массива
        }

        /// <summary>
        /// Метод для нахождения индекса максимального элемента массива.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <returns>Индекс максимального элемента в массиве.</returns>
        static int FindMaxElementIndex(int[] array)
        {
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i; // Обновление индекса если найден больший элемент
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// Метод для замены максимального элемента массива на введенное число.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="newValue">Новое значение которым будет заменён максимальный элемент.</param>
        static void ReplaceMaxElement(int[] array, int newValue)
        {
            // Нахождение индекса максимального элемента
            int maxIndex = FindMaxElementIndex(array);

            // Замена максимального элемента на введённое значение
            array[maxIndex] = newValue;
        }
    }
}
