using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1_2
{
    internal class Task5
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            PlayFizzBuzz();
        }

        /// <summary>
        /// Основной метод, который выполняет логику игры FizzBuzz:
        /// выводит числа от 1 до 100 с заменой на "Fizz", "Buzz" или "FizzBuzz".
        /// </summary>
        static void PlayFizzBuzz()
        {
            // Цикл для чисел от 1 до 100
            for (int i = 1; i <= 100; i++)
            {
                // Метод для определения и вывода результата для каждого числа
                Console.WriteLine(GetFizzBuzzValue(i));
            }
        }

        /// <summary>
        /// Метод возвращает строковое значение для текущего числа:
        /// "Fizz", если число кратно 3, "Buzz", если кратно 5,
        /// "FizzBuzz", если кратно и 3, и 5, или само число в виде строки.
        /// </summary>
        /// <param name="number">Текущее число для проверки</param>
        /// <returns>Строка с результатом "Fizz", "Buzz", "FizzBuzz" или число как строка</returns>
        static string GetFizzBuzzValue(int number)
        {
            // Если число делится на 3 и на 5 return "FizzBuzz"
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            // Если число делится на 3 return "Fizz"
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            // Если число делится на 5 return "Buzz"
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            // Иначе return число
            else
            {
                return number.ToString();
            }
        }
    }
}
