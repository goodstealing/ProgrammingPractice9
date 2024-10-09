using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    internal class Task1
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Создание объектов класса Person
            Person person1 = new();
            person1.SetName("Паша");
            person1.SetAge(10);
            person1.SetAddress("Москва, ул. Проспект");

            Person person2 = new();
            person2.SetName("Андрей");
            person2.SetAge(21);
            person2.SetAddress("Москва, ул. Пушкина 9Г");

            // Вывод информации о людях
            person1.PrintPerson();
            person2.PrintPerson();
        }
        public class Person
        {
            // Поля класса
            private string ?name;
            private int age;
            private string ?address;

            public void SetName(string name) => this.name = name;

            public string ReturnName() => name;

            public void SetAge(int age) => this.age = age;

            public int ReturnAge() => age;

            public void SetAddress(string address) => this.address = address;

            public string ReturnAddress() => address;

            public void PrintPerson()
            {
                Console.WriteLine($"Имя: {name}, Возраст: {age}, Адрес: {address}");
            }
        }
    }
}
