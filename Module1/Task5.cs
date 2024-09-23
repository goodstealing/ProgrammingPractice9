using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{
    internal class Task5
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            int age = GetUserAge();
            bool canGetLicense = CanGetDriverLicense(age);

            // Вывод результата проверки
            if (canGetLicense)
            {
                Console.CursorVisible = false;
                Console.WriteLine("Вы можете получить водительские права.");
            }
            else
            {
                Console.WriteLine("Вы еще не можете получить водительские права.");
            }
        }

        /// <summary>
        /// Запрашивает у пользователя его возраст.
        /// </summary>
        /// <returns>Возраст пользователя в виде целого числа.</returns>
        static int GetUserAge()
        {
            Console.Write("Введите ваш возраст: ");
            string ?input = Console.ReadLine();

            // Преобразование ввода в int
            if (int.TryParse(input, out int age))
            {
                return age;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                return GetUserAge(); // Повторение запроса
            }
        }

        /// <summary>
        /// Определяет, может ли пользователь получить водительские права на основе возраста.
        /// </summary>
        /// <param name="age">Возраст пользователя.</param>
        /// <returns>true, если возраст 18 лет или больше; иначе false.</returns>
        static bool CanGetDriverLicense(int age)
        {
            return age >= 18;
        }
    }
}
