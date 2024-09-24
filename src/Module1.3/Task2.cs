using System;

namespace Module1_3
{
    internal class Task2
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Ввод максимальной суммы
            int maxSum = GetMaxSum();

            // Создание массива с случайными значениями
            int[] randomArray = CreateRandomArray();

            // Формирование нового массива с минимальным количеством элементов
            int[] resultArray = CreateMinElementArray(randomArray, maxSum);

            PrintResult(resultArray, maxSum);
        }

        /// <summary>
        /// Метод для ввода максимальной суммы с проверкой корректности ввода.
        /// </summary>
        /// <returns>Корректная максимальная сумма</returns>
        private static int GetMaxSum()
        {
            int maxSum;
            Console.Write("Введите максимальную сумму: ");
            while (!int.TryParse(Console.ReadLine(), out maxSum) || maxSum <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное число.");
            }
            return maxSum;
        }

        /// <summary>
        /// Метод для создания массива случайных чисел от 1 до 9.
        /// </summary>
        /// <returns>Массив с случайными числами</returns>
        private static int[] CreateRandomArray()
        {
            Random random = new Random();
            int[] array = new int[10]; // Фиксированный размер массива 10

            // Заполнение массива случайными числами от 1 до 9
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10); // Генерация случайного числа от 1 до 9
            }
            return array;
        }

        /// <summary>
        /// Метод для создания нового массива с минимальным количеством элементов,
        /// сумма которых не превышает заданное значение.
        /// </summary>
        /// <param name="inputArray">Исходный массив случайных чисел</param>
        /// <param name="maxSum">Максимальная сумма</param>
        /// <returns>Новый массив с минимальным количеством элементов</returns>
        private static int[] CreateMinElementArray(int[] inputArray, int maxSum)
        {
            int currentSum = 0;
            var resultList = new List<int>(); // Список для хранения результатов

            // Сортировка массива для минимизации количества элементов
            Array.Sort(inputArray);

            // Сбор элементов до достижения максимальной суммы
            foreach (int number in inputArray)
            {
                if (currentSum + number <= maxSum) // Проверка на превышение суммы
                {
                    currentSum += number; // Добавление числа к текущей сумме
                    resultList.Add(number); // Добавление числа в результирующий список
                }
                else
                {
                    break; // Прерывание если добавление числа превысит максимальную сумму
                }
            }

            return [.. resultList]; // Преобразование списка в массив
        }

        /// <summary>
        /// Метод для вывода результатов.
        /// </summary>
        /// <param name="resultArray">Массив с минимальным количеством элементов</param>
        /// <param name="maxSum">Максимальная сумма</param>
        private static void PrintResult(int[] resultArray, int maxSum)
        {
            Console.CursorVisible = false;
            Console.WriteLine($"Сумма элементов не превышает {maxSum}.");
            Console.WriteLine("Результирующий массив:");

            if (resultArray.Length == 0)
            {
                Console.WriteLine("Нет элементов, подходящих под условия.");
            }
            else
            {
                foreach (int value in resultArray)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
