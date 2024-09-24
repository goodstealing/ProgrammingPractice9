using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1_2
{
    internal class Task3
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            // Запрашивает ввод строк у пользователя и проверяет, является ли вторая строка подстрокой первой
            string firstString = InputString("Введите первую строку: ");
            string secondString = InputString("Введите вторую строку: ");

            // Проверка, является ли вторая строка подстрокой первой
            bool isSubstring = CheckIfSubstring(firstString, secondString);
            PrintResult(isSubstring, secondString);
        }

        /// <summary>
        /// Метод для ввода строки пользователем
        /// </summary>
        /// <param name="prompt">Сообщение, которое будет отображено перед вводом</param>
        /// <returns>Возвращает введённую строку</returns>
        private static string InputString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Метод для проверки, является ли одна строка подстрокой другой
        /// </summary>
        /// <param name="firstString">Первая строка, в которой ищем</param>
        /// <param name="secondString">Вторая строка, которую ищем</param>
        /// <returns>Возвращает true, если вторая строка является подстрокой первой, иначе false</returns>
        private static bool CheckIfSubstring(string firstString, string secondString)
        {
            // Contains проверяет наличие подстроки в строке
            return firstString.Contains(secondString);
        }

        /// <summary>
        /// Метод для вывода результата
        /// </summary>
        /// <param name="isSubstring">Результат проверки, является ли подстрока частью строки</param>
        /// <param name="secondString">Строка, которую проверяли как подстроку</param>
        private static void PrintResult(bool isSubstring, string secondString)
        {
            Console.CursorVisible = false;

            if (isSubstring)
            {
                Console.WriteLine($"Строка \"{secondString}\" является подстрокой.");
            }
            else
            {
                Console.WriteLine($"Строка \"{secondString}\" не является подстрокой.");
            }
        }
    }
}
