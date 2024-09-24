using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{
    internal class Task3
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.Write("Введите Имя: ");
            string? name = Console.ReadLine();
            Console.Write("Введите Фамилию: ");
            string? surname = Console.ReadLine();

            Console.WriteLine($"{surname},{name}"); // Вывод "Фамилия, Имя"
        }
    }
}
