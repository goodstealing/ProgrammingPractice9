using System;

namespace Module1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DisplayInstructions(); // Инструкции для пользователя

            bool exit = false; // Переменная для контроля выхода из программы

            while (!exit)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char key = keyInfo.KeyChar;

                if (char.IsDigit(key) && key >= '1' && key <= '9')
                {
                    ExecuteTask(key);
                }
                else if (key == (char)ConsoleKey.Escape)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("/Ожидаются цифры от 1 до 9 или 0/");
                }
            }
        }

        /// <summary>
        /// Выводит инструкции по использованию программы.
        /// </summary>
        static void DisplayInstructions()
        {
            Console.WriteLine("| Система Запуска Заданий | Вариант 2 |");
            Console.WriteLine("| Для продолжения выберите номер задания и нажмите соответствующую клавишу |");
            Console.WriteLine("| Пример: клавиша 1 - Задание 1 | Для выхода 'Esc' |\n");
        }

        /// <summary>
        /// Выполняет запуск задания по номеру, основанному на нажатой клавише.
        /// </summary>
        /// <param name="key">Символ, представляющий номер задания.</param>
        /// <remarks>
        /// Использует рефлексию для поиска и вызова метода Execute() класса,
        /// соответствующего номеру задания. Выводит сообщения об ошибках, если
        /// класс или метод не найдены.
        /// </remarks>
        static void ExecuteTask(char key)
        {
            int taskNumber = key - '0'; // Символ => целое число
            string className = $"Task{taskNumber}"; // Формирование имени класса

            // Рефлексия для поиска и вызова метода Execute
            Type? taskType = Type.GetType($"Module1_2.{className}");
            if (taskType != null)
            {
                var method = taskType.GetMethod("Execute");
                if (method != null)
                {
                    method.Invoke(null, null); // Вызов метода Execute
                }
                else
                {
                    Console.WriteLine($"Метод Execute() не найден в классе '{className}'.");
                }
            }
            else
            {
                Console.WriteLine($"| Запуск: Класс {className} не найден, запуск невозможен.");
            }
        }
    }
}
