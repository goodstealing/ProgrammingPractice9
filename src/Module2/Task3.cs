using System;

namespace Module2
{
    internal class Task3
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Создание объектов класса Author
            Author author1 = new("Фёдор Фёдоров", 1128);
            Author author2 = new("Алексей Достоевский", 1828);

            // Создание объектов класса Book, которые связаны с объектами Author
            Book book1 = new("Песня", 1159, author1);
            Book book2 = new("Do you belive in C-sharp", 1866, author2);

            // Вывод информации о книгах и их авторах
            book1.PrintBook();
            Console.WriteLine();
            book2.PrintBook();
        }
    }
    public class Author
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }

        // Конструктор инициализации автора
        public Author(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }

        public void PrintAuthor()
        {
            Console.WriteLine($"Автор: {Name}, Год рождения: {BirthYear}");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Author Author { get; set; }  // Композиция: объект Author внутри Book

        // Конструктор инициализации книги и связывания с автором
        public Book(string title, int year, Author author)
        {
            Title = title;
            Year = year;
            Author = author;
        }
        public void PrintBook()
        {
            Console.WriteLine($"Книга: {Title}, Год выпуска: {Year}");
            Author.PrintAuthor();
        }
    }
}
