using System;

namespace Module2
{
    internal class Task7
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Создаем массив студентов (10 элементов)
            Student[] students = new Student[]
            {
            new Student { LastName = "Иванов", Initials = "А.И.", GroupNumber = 101, Grades = [5, 4, 4, 5, 5] },
            new Student { LastName = "Петров", Initials = "Б.В.", GroupNumber = 102, Grades = [3, 4, 5, 4, 5] },
            new Student { LastName = "Сидоров", Initials = "В.Г.", GroupNumber = 101, Grades = [2, 3, 3, 4, 2] },
            new Student { LastName = "Кузнецов", Initials = "Г.Д.", GroupNumber = 103, Grades = [4, 4, 4, 4, 4] },
            new Student { LastName = "Смирнов", Initials = "Д.Е.", GroupNumber = 104, Grades = [5, 5, 5, 5, 5] },
            new Student { LastName = "Федоров", Initials = "Е.Ж.", GroupNumber = 102, Grades = [5, 4, 3, 5, 4] },
            new Student { LastName = "Морозов", Initials = "Ж.З.", GroupNumber = 101, Grades = [3, 3, 3, 4, 4] },
            new Student { LastName = "Волков", Initials = "З.И.", GroupNumber = 103, Grades = [4, 5, 4, 5, 4] },
            new Student { LastName = "Михайлов", Initials = "И.К.", GroupNumber = 104, Grades = [5, 5, 5, 5, 4] },
            new Student { LastName = "Титов", Initials = "К.Л.", GroupNumber = 105, Grades = [4, 4, 4, 4, 4] }
            };

            // Сортируем студентов по возрастанию среднего балла
            var sortedStudents = students.OrderBy(s => s.GetAverageGrade()).ToArray();

            Console.WriteLine("Студенты, отсортированные по среднему баллу:");
            foreach (var student in sortedStudents)
            {
                student.DisplayInfo();
            }

            Console.WriteLine("\nСтуденты, у которых оценки только 4 или 5:");
            foreach (var student in sortedStudents)
            {
                if (student.HasOnlyHighGrades())
                {
                    Console.WriteLine($"Фамилия: {student.LastName}, Номер группы: {student.GroupNumber}");
                }
            }
        }
    }

    public struct Student
    {
        public string LastName { get; set; }         // Фамилия
        public string Initials { get; set; }         // Инициалы
        public int GroupNumber { get; set; }         // Номер группы
        public int[] Grades { get; set; }            // Массив из пяти оценок

        // Метод для расчета среднего балла
        public double GetAverageGrade()
        {
            return Grades.Average();
        }

        // Метод для проверки, что все оценки равны 4 или 5
        public bool HasOnlyHighGrades()
        {
            return Grades.All(grade => grade == 4 || grade == 5);
        }

        // Метод для вывода информации о студенте
        public void DisplayInfo()
        {
            Console.WriteLine($"Фамилия: {LastName}, Инициалы: {Initials}, Номер группы: {GroupNumber}, Средний балл: {GetAverageGrade():F2}");
        }
    }
}
