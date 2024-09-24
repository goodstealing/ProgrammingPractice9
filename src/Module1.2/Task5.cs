using System;

namespace Module1_2
{
    internal class Task5
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Ввод количества элементов массива
            int K = GetArraySize();
            // Генерация массива с случайными буквами русского алфавита
            char[] randomChars = GenerateRandomCharArray(K);
            // Создание массива, содержащего только согласные буквы
            char[] consonantsArray = FilterConsonants(randomChars);

            PrintArray("Сгенерированный массив:", randomChars);
            PrintArray("Массив согласных букв:", consonantsArray);
        }

        /// <summary>
        /// Метод для ввода размера массива с проверкой корректности.
        /// </summary>
        /// <returns>Размер массива</returns>
        private static int GetArraySize()
        {
            int K;
            Console.Write("Введите количество элементов массива K: ");
            while (!int.TryParse(Console.ReadLine(), out K) || K <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное число для размера массива.");
            }
            return K;
        }

        /// <summary>
        /// Метод для генерации массива случайных букв русского алфавита.
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <returns>Массив случайных букв</returns>
        private static char[] GenerateRandomCharArray(int size)
        {
            char[] chars = new char[size];
            Random random = new();
            for (int i = 0; i < size; i++)
            {
                // Генерация случайной буквы русского алфавита от а до я
                chars[i] = (char)random.Next('а', 'я' + 1);
            }
            return chars;
        }

        /// <summary>
        /// Метод для фильтрации согласных букв из массива.
        /// </summary>
        /// <param name="chars">Исходный массив символов</param>
        /// <returns>Массив согласных букв</returns>
        private static char[] FilterConsonants(char[] chars)
        {
            // Определение массива согласных букв
            char[] consonants = "бвгджзйлмнпрстфхцчшщ".ToCharArray();
            char[] result = Array.FindAll(chars, c => Array.Exists(consonants, consonant => consonant == c));
            return result;
        }

        /// <summary>
        /// Метод для вывода элементов массива.
        /// </summary>
        /// <param name="message">Сообщение для вывода перед массивом</param>
        /// <param name="array">Массив для вывода</param>
        private static void PrintArray(string message, char[] array)
        {
            Console.CursorVisible = false;
            Console.WriteLine(message);
            foreach (char c in array)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
