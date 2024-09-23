using System;

namespace Module1
{
    internal class Task1
    {
        // Nullable строка для хранения ввода пользователя
        public static string? userinput;

        /// <summary>
        /// Определение четного или нечетного числа.
        /// </summary>
        /// <returns>Вывод четного или нечетного числа на консоль.</returns>
        public static void Execute()
        {

            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите целое число: ");
            string? userinput = Console.ReadLine();

            // Проверка введённой строки на соответствие целому числу
            if (int.TryParse(userinput, out _))
            {
                int number = int.Parse(userinput);
                Console.WriteLine($"Число {number} соответствует требованиям.");

                // Проверка чётное|нечётное
                if (number % 2 == 0)
                {
                    Console.WriteLine($"Число: {number} чётное."); 
                }
                else
                {
                    Console.WriteLine($"Число: {number} нечётное."); 
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введено не целое число.");
            }
            Console.WriteLine("\n| Запустить другое задание? | Выход 'Esc' |");
        }
    }
}
